﻿//-----------------------------------------------------------------------
// <copyright file="GetSystemUptime.cs" company="None">
//     Copyright (c) felsokning. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Public.WindowsWorkflows.Research
{
    using System;
    using System.Activities;
    using System.Management.Automation;
    using System.Reflection;
    using System.Runtime.Remoting;

    /// <summary>
    ///     Initializes a new instance of the <see cref="InvokeWindowsWorkflow"/> class.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "WindowsWorkflow")]
    public class InvokeWindowsWorkflow : Cmdlet
    {
        /// <summary>
        ///     Gets or sets the value for the <see cref="AssemblyPath"/> parameter.
        ///     The assembly path is where the compiled assembly for the activity should be found.
        /// </summary>
        [Parameter(HelpMessage = "Path to the Workflow Assembly.", Mandatory = true)]
        public string AssemblyPath { get; set; }

        /// <summary>
        ///     Gets or sets the value for the <see cref="Type"/> parameter.
        ///     The type will be exposed in the assembly. To verify the type, use assembly.ExportedTypes
        ///     to discover the type. Do note that the fully-qualified type name will be required.
        /// </summary>
        [Parameter(HelpMessage = "The Type contained within the assembly", Mandatory = true)]
        public string Type { get; set; }

        /// <summary>
        ///     Overrides the <see cref="ProcessRecord"/> method inherited from <see cref="Cmdlet"/>.
        /// </summary>
        protected override void ProcessRecord()
        {
            // See Public.Activities.Research for examples of Activities that you can use here.
            Assembly assembly = Assembly.LoadFrom(AssemblyPath);
            ObjectHandle testCodeActivityObject = Activator.CreateInstance(assembly.FullName, Type);

            WorkflowApplication newWorkflowApplication = new WorkflowApplication((Activity)testCodeActivityObject.Unwrap());
            newWorkflowApplication.Completed += delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine("Workflow {0} Terminated.", e.InstanceId);
                    Console.WriteLine("Exception: {0}\n{1}",
                        e.TerminationException.GetType().FullName,
                        e.TerminationException.Message);
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine("Workflow {0} Canceled.", e.InstanceId);
                }
                else
                {
                    Console.WriteLine("Workflow {0} Completed at {1}. \n\tResult: {2} ", e.InstanceId, DateTime.UtcNow, e.Outputs["Result"]);
                }
            };

            newWorkflowApplication.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                // The workflow aborted, so let's find out why.
                Console.WriteLine("Workflow {0} has been aborted.", e.InstanceId);
                Console.WriteLine("Exception: {0}\n{1}",
                    e.Reason.GetType().FullName,
                    e.Reason.Message);
            };

            newWorkflowApplication.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // NOTE: If the workflow can persist, both Idle and PersistableIdle are called in that order.
                Console.WriteLine("Workflow {0} Idle.", e.InstanceId);
            };

            newWorkflowApplication.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Runtime will persist.
                return PersistableIdleAction.Unload;
            };

            newWorkflowApplication.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine("Workflow {0} Unloaded.", e.InstanceId);
            };

            newWorkflowApplication.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine("OnUnhandledException in Workflow {0}\n{1}",
                    e.InstanceId, e.UnhandledException.Message);

                Console.WriteLine("ExceptionSource: {0} - {1}",
                    e.ExceptionSource.DisplayName, e.ExceptionSourceInstanceId);

                // Instruct the runtime to terminate the workflow.
                // The other viable choices here are 'Abort' or 'Cancel'
                return UnhandledExceptionAction.Terminate;
            };

            newWorkflowApplication.Run();
        }
    }
}