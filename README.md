# CSharp
This is C# code (often a DLL) for reference/example.

## Public.Debugging.Research
The module is written to be directly imported into PowerShell.

```
Import-Module ".\Public.Debugging.Research.dll" -Verbose
VERBOSE: Loading module from path '.\Public.Debugging.Research.dll'.
VERBOSE: Importing cmdlet 'Debug-DumpFile'.
VERBOSE: Importing cmdlet 'Debug-LiveProcess'.
```

### DebugDumpFile
PowerShell Command (Debug-DumpFile) written to dump the threads from a dump file.

Example (redacted for brevity):
```
Debug-DumpFile -FilePath "C:\Users\Public\Downloads\Dumps\13.Jan.2019_19.18_powershell_9544.dmp.mini0"
2AD8
  dd44a7d2c8            0 mscorlib [HelperMethodFrame_1OBJ] (System.Threading.WaitHandle.WaitOneNative)
  dd44a7d3f0 7ffacb07efdb mscorlib System.Threading.WaitHandle.InternalWaitOne(System.Runtime.InteropServices.SafeHandle, Int64, Boolean, Boolean)
  dd44a7d420 7ffacb07efae mscorlib System.Threading.WaitHandle.WaitOne(Int32, Boolean)
  dd44a7d460 7ffac1c46b33 System.Management.Automation System.Management.Automation.Runspaces.PipelineBase.Invoke(System.Collections.IEnumerable)
  dd44a7d4a0 7ffac1dde7be System.Management.Automation System.Management.Automation.PowerShell+Worker.ConstructPipelineAndDoWork(System.Management.Automation.Runspaces.Runspace, Boolean)
  dd44a7d570 7ffac1dde1dd System.Management.Automation System.Management.Automation.PowerShell+Worker.CreateRunspaceIfNeededAndDoWork(System.Management.Automation.Runspaces.Runspace, Boolean)
  dd44a7d5e0 7ffac1c95048 System.Management.Automation System.Management.Automation.PowerShell.CoreInvokeHelper[[System.__Canon, mscorlib],[System.__Canon, mscorlib]](System.Management.Automation.PSDataCollection`1<System.__Canon>, System.Management.Automation.PSDataCollection`1<System.__Canon>, System.Management.Automation.PSInvocationSettings)
  dd44a7d650 7ffac1c9555a System.Management.Automation System.Management.Automation.PowerShell.CoreInvoke[[System.__Canon, mscorlib],[System.__Canon, mscorlib]](System.Management.Automation.PSDataCollection`1<System.__Canon>, System.Management.Automation.PSDataCollection`1<System.__Canon>, System.Management.Automation.PSInvocationSettings)
  dd44a7d6d0 7ffac1c9256e System.Management.Automation System.Management.Automation.PowerShell.Invoke(System.Collections.IEnumerable, System.Management.Automation.PSInvocationSettings)
  dd44a7d730 7ffaa2320816 Microsoft.PowerShell.ConsoleHost Microsoft.PowerShell.ConsoleHostUserInterface.TryInvokeUserDefinedReadLine(System.String ByRef)
  dd44a7d790 7ffaa2320018 Microsoft.PowerShell.ConsoleHost Microsoft.PowerShell.ConsoleHostUserInterface.ReadLineWithTabCompletion(Microsoft.PowerShell.Executor)
  dd44a7d850 7ffaa2323e32 Microsoft.PowerShell.ConsoleHost Microsoft.PowerShell.ConsoleHost+InputLoop.Run(Boolean)
  dd44a7d900 7ffaa23239fd Microsoft.PowerShell.ConsoleHost Microsoft.PowerShell.ConsoleHost+InputLoop.RunNewInputLoop(Microsoft.PowerShell.ConsoleHost, Boolean)
  dd44a7d950 7ffaa2317429 Microsoft.PowerShell.ConsoleHost Microsoft.PowerShell.ConsoleHost.EnterNestedPrompt()
  dd44a7d9b0 7ffaa231831c Microsoft.PowerShell.ConsoleHost Microsoft.PowerShell.ConsoleHost.DoRunspaceLoop(System.String, Boolean, System.Collections.ObjectModel.Collection`1<System.Management.Automation.Runspaces.CommandParameter>, Boolean, Boolean, System.String)
  dd44a7da30 7ffaa231819a Microsoft.PowerShell.ConsoleHost Microsoft.PowerShell.ConsoleHost.Run(Microsoft.PowerShell.CommandLineParameterParser, Boolean)
  dd44a7daa0 7ffaa2316626 Microsoft.PowerShell.ConsoleHost Microsoft.PowerShell.ConsoleHost.Start(System.Management.Automation.Runspaces.RunspaceConfiguration, System.String, System.String, System.String, System.String[])
  dd44a7db20 7ffaa232db8b Microsoft.PowerShell.ConsoleHost Microsoft.PowerShell.UnmanagedPSEntry.Start(System.String, System.String[])
  dd44a7de28            0 UNKNOWN [DebuggerU2MCatchHandlerFrame]
  dd44a7e168            0 mscorlib [HelperMethodFrame_PROTECTOBJ] (System.RuntimeMethodHandle.InvokeMethod)
  dd44a7e2e0 7ffacb0d44e0 mscorlib System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(System.Object, System.Object[], System.Object[])
  dd44a7e350 7ffacb0bf4ee mscorlib System.Reflection.RuntimeMethodInfo.Invoke(System.Object, System.Reflection.BindingFlags, System.Reflection.Binder, System.Object[], System.Globalization.CultureInfo)
  dd44a7f440            0 UNKNOWN [DebuggerU2MCatchHandlerFrame]
  dd44a7f490            0 UNKNOWN [GCFrame]
  dd44a7f458            0 UNKNOWN [GCFrame]
2B90
  dd4533e7a8            0 mscorlib [HelperMethodFrame_1OBJ] (System.Threading.WaitHandle.WaitOneNative)
  dd4533e8d0 7ffacb07efdb mscorlib System.Threading.WaitHandle.InternalWaitOne(System.Runtime.InteropServices.SafeHandle, Int64, Boolean, Boolean)
  dd4533e900 7ffacb07efae mscorlib System.Threading.WaitHandle.WaitOne(Int32, Boolean)
  dd4533e940 7ffac7c63d14 System.Core System.IO.Pipes.NamedPipeServerStream.EndWaitForConnection(System.IAsyncResult)
  dd4533e9a0 7ffac20835dc System.Management.Automation System.Management.Automation.Remoting.RemoteSessionNamedPipeServer.ProcessListeningThread(System.Object)
  dd4533ead0 7ffacb0c3a63 mscorlib System.Threading.ExecutionContext.RunInternal(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object, Boolean)
  dd4533eba0 7ffacb0c38f4 mscorlib System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object, Boolean)
  dd4533ebd0 7ffacb0c38c2 mscorlib System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object)
  dd4533ec20 7ffacba71afc mscorlib System.Threading.ThreadHelper.ThreadStart(System.Object)
  dd4533ee78            0 UNKNOWN [GCFrame]
  dd4533f1c8            0 UNKNOWN [DebuggerU2MCatchHandlerFrame]
```

### DebugLiveProcess
PowerShell Command (Debug-LiveProcess) written to dump the threads from a live process.

## Public.Exchange.Research
DLL meant to be imported into PowerShell via a PowerShell Script, which performs mass commands in parallel against an array of servers.

## Public.ExtensionMethods.Research
DLL/Class meant to be imported to extend types in .NET

### Veckan
Extends the [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netframework-4.7.2) type to return the [ISO week number](https://en.wikipedia.org/wiki/ISO_week_date#Calculating_the_week_number_of_a_given_date) from a given date.

```
int weekNumber = dateTime.Veckan();
```
