﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MFCcontrol.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500")]
        public int ADacquireTime_ms {
            get {
                return ((int)(this["ADacquireTime_ms"]));
            }
            set {
                this["ADacquireTime_ms"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("200")]
        public int timerUI_ms {
            get {
                return ((int)(this["timerUI_ms"]));
            }
            set {
                this["timerUI_ms"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int MFCcontrol_numMFCs {
            get {
                return ((int)(this["MFCcontrol_numMFCs"]));
            }
            set {
                this["MFCcontrol_numMFCs"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dev1/ai0,Dev1/ai1,Dev1/ai2,Dev1/ai3,Dev1/ai4,Dev1/ai5,Dev1/ai6,Dev1/ai7")]
        public string MfcAinChannelsList {
            get {
                return ((string)(this["MfcAinChannelsList"]));
            }
            set {
                this["MfcAinChannelsList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("200")]
        public int ADoutRefreshTime_ms {
            get {
                return ((int)(this["ADoutRefreshTime_ms"]));
            }
            set {
                this["ADoutRefreshTime_ms"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500")]
        public int GraphTimeUpdateMS {
            get {
                return ((int)(this["GraphTimeUpdateMS"]));
            }
            set {
                this["GraphTimeUpdateMS"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool PicoammeterControlEnable {
            get {
                return ((bool)(this["PicoammeterControlEnable"]));
            }
            set {
                this["PicoammeterControlEnable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool mfcMainControlEnable {
            get {
                return ((bool)(this["mfcMainControlEnable"]));
            }
            set {
                this["mfcMainControlEnable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".1")]
        public string sensorVdsDaqAO {
            get {
                return ((string)(this["sensorVdsDaqAO"]));
            }
            set {
                this["sensorVdsDaqAO"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public string sensorVgsDaqAO {
            get {
                return ((string)(this["sensorVgsDaqAO"]));
            }
            set {
                this["sensorVgsDaqAO"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool sensorBiasEnable {
            get {
                return ((bool)(this["sensorBiasEnable"]));
            }
            set {
                this["sensorBiasEnable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool sensorVdsDaqLock {
            get {
                return ((bool)(this["sensorVdsDaqLock"]));
            }
            set {
                this["sensorVdsDaqLock"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool sensorVgsDaqLock {
            get {
                return ((bool)(this["sensorVgsDaqLock"]));
            }
            set {
                this["sensorVgsDaqLock"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public double sensorBiasMaxRange {
            get {
                return ((double)(this["sensorBiasMaxRange"]));
            }
            set {
                this["sensorBiasMaxRange"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int PicoammRange {
            get {
                return ((int)(this["PicoammRange"]));
            }
            set {
                this["PicoammRange"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool PicoammRefreshRead {
            get {
                return ((bool)(this["PicoammRefreshRead"]));
            }
            set {
                this["PicoammRefreshRead"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6")]
        public double PicoammNPLC {
            get {
                return ((double)(this["PicoammNPLC"]));
            }
            set {
                this["PicoammNPLC"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2000")]
        public int SamplesToGraphRst {
            get {
                return ((int)(this["SamplesToGraphRst"]));
            }
            set {
                this["SamplesToGraphRst"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True,True,True,True,True,True,True,True")]
        public string MfcControlEnableList {
            get {
                return ((string)(this["MfcControlEnableList"]));
            }
            set {
                this["MfcControlEnableList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1,2,3,4,5,6,7,8")]
        public string MfcGasNamesList {
            get {
                return ((string)(this["MfcGasNamesList"]));
            }
            set {
                this["MfcGasNamesList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1000,100,100,100,1000,100,100,100")]
        public string MfcMaxRangeList {
            get {
                return ((string)(this["MfcMaxRangeList"]));
            }
            set {
                this["MfcMaxRangeList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True,True,True,True,True,True,True,True")]
        public string MfcPlotEnableList {
            get {
                return ((string)(this["MfcPlotEnableList"]));
            }
            set {
                this["MfcPlotEnableList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dev1/ao0,Dev1/ao1,Dev1/ao0,Dev1/ao1,,,,")]
        public string MfcAoutChannelsList {
            get {
                return ((string)(this["MfcAoutChannelsList"]));
            }
            set {
                this["MfcAoutChannelsList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dev1/ao0")]
        public string sensorVdsDaqAOchan {
            get {
                return ((string)(this["sensorVdsDaqAOchan"]));
            }
            set {
                this["sensorVdsDaqAOchan"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dev1/ao1")]
        public string sensorVgsDaqAOchan {
            get {
                return ((string)(this["sensorVgsDaqAOchan"]));
            }
            set {
                this["sensorVgsDaqAOchan"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public double sensorBiasMinRange {
            get {
                return ((double)(this["sensorBiasMinRange"]));
            }
            set {
                this["sensorBiasMinRange"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PXI1Slot2")]
        public string PxiResourceName {
            get {
                return ((string)(this["PxiResourceName"]));
            }
            set {
                this["PxiResourceName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2535/1-Wire 4x136 Matrix")]
        public string SwitchTopologyName {
            get {
                return ((string)(this["SwitchTopologyName"]));
            }
            set {
                this["SwitchTopologyName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SwitchMatrixEnable {
            get {
                return ((bool)(this["SwitchMatrixEnable"]));
            }
            set {
                this["SwitchMatrixEnable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500")]
        public double SwitchRefreshMs {
            get {
                return ((double)(this["SwitchRefreshMs"]));
            }
            set {
                this["SwitchRefreshMs"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SwitchRefreshEnable {
            get {
                return ((bool)(this["SwitchRefreshEnable"]));
            }
            set {
                this["SwitchRefreshEnable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public int SwitchMatrixRowsNum {
            get {
                return ((int)(this["SwitchMatrixRowsNum"]));
            }
            set {
                this["SwitchMatrixRowsNum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("136")]
        public int SwitchMatrixColsNum {
            get {
                return ((int)(this["SwitchMatrixColsNum"]));
            }
            set {
                this["SwitchMatrixColsNum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool SweepMatrixDuringRecipe {
            get {
                return ((bool)(this["SweepMatrixDuringRecipe"]));
            }
            set {
                this["SweepMatrixDuringRecipe"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DigitalOutputEnable {
            get {
                return ((bool)(this["DigitalOutputEnable"]));
            }
            set {
                this["DigitalOutputEnable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int DigitalOutputNumLines {
            get {
                return ((int)(this["DigitalOutputNumLines"]));
            }
            set {
                this["DigitalOutputNumLines"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dev1/Port0/line0,Dev1/Port0/line1,Dev1/Port0/line2,Dev1/Port0/line3,Dev1/Port0/li" +
            "ne4,Dev1/Port0/line5,Dev1/Port0/line6,Dev1/Port0/line7")]
        public string DigitalOutputLineNames {
            get {
                return ((string)(this["DigitalOutputLineNames"]));
            }
            set {
                this["DigitalOutputLineNames"] = value;
            }
        }
    }
}
