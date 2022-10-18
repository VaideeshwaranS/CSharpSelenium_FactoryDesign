using System;
using System.Collections.Generic;
using System.Text;

namespace CustomFrameworkPOC.PerformanceMetrics
{
    public class PerformanceMetricsMap
    {
        public double Timestamp { get => Timestamp; set => Timestamp = value; }
        public double AudioHandlers { get => AudioHandlers; set => AudioHandlers = value; }
        public double Documents { get => Documents; set => Documents = value; }
        public double Frames { get => Frames; set => Frames = value; }
        public double JSEventListeners { get => JSEventListeners; set => JSEventListeners = value; }
        public double LayoutObjects { get => LayoutObjects; set => LayoutObjects = value; }
        public double MediaKeySessions { get => MediaKeySessions; set => MediaKeySessions = value; }
        public double MediaKeys { get => MediaKeys; set => MediaKeys = value; }
        public double Nodes { get => Nodes; set => Nodes = value; }
        public double Resources { get => Resources; set => Resources = value; }
        public double ContextLifecycleStateObservers { get => ContextLifecycleStateObservers; set => ContextLifecycleStateObservers = value; }
        public double V8PerContextDatas { get => V8PerContextDatas; set => V8PerContextDatas = value; }
        public double WorkerGlobalScopes { get => WorkerGlobalScopes; set => WorkerGlobalScopes = value; }
        public double UACSSResources { get => UACSSResources; set => UACSSResources = value; }
        public double RTCPeerConnections { get => RTCPeerConnections; set => RTCPeerConnections = value; }
        public double ResourceFetchers { get => ResourceFetchers; set => ResourceFetchers = value; }
        public double AdSubframes { get => AdSubframes; set => AdSubframes = value; }
        public double DetachedScriptStates { get => DetachedScriptStates; set => DetachedScriptStates = value; }
        public double ArrayBufferContents { get => ArrayBufferContents; set => ArrayBufferContents = value; }
        public double LayoutCount { get => LayoutCount; set => LayoutCount = value; }
        public double RecalcStyleCount { get => RecalcStyleCount; set => RecalcStyleCount = value; }
        public double LayoutDuration { get => LayoutDuration; set => LayoutDuration = value; }
        public double RecalcStyleDuration { get => RecalcStyleDuration; set => RecalcStyleDuration = value; }
        public double DevToolsCommandDuration { get => DevToolsCommandDuration; set => DevToolsCommandDuration = value; }
        public double ScriptDuration { get => ScriptDuration; set => ScriptDuration = value; }
        public double V8CompileDuration { get => V8CompileDuration; set => V8CompileDuration = value; }
        public double TaskDuration { get => TaskDuration; set => TaskDuration = value; }
        public double TaskOtherDuration { get => TaskOtherDuration; set => TaskOtherDuration = value; }
        public double ThreadTime { get => ThreadTime; set => ThreadTime = value; }
        public double ProcessTime { get => ProcessTime; set => ProcessTime = value; }
        public double JSHeapUsedSize { get => JSHeapUsedSize; set => JSHeapUsedSize = value; }
        public double JSHeapTotalSize { get => JSHeapTotalSize; set => JSHeapTotalSize = value; }
        public double FirstMeaningfulPaint { get => FirstMeaningfulPaint; set => FirstMeaningfulPaint = value; }
        public double DomContentLoaded { get => DomContentLoaded; set => DomContentLoaded = value; }
        public double NavigationStart { get => NavigationStart; set => NavigationStart = value; }
    }
}
