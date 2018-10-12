using System;
using System.Windows.Forms;

namespace Check_Transmission_OutlookAddIn {
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class MyPropPage1 : UserControl, Microsoft.Office.Interop.Outlook.PropertyPage {
        private Microsoft.Office.Interop.Outlook.PropertyPageSite _propertyPageSite;

        public MyPropPage1() {
            InitializeComponent();

            numericUpDownWaitingTime.Value = Properties.Settings.Default.WaitingTime;
            numericUpDownWaitingTime.ValueChanged += numericUpDownChanged;

            void numericUpDownChanged(object sender, EventArgs e) {
                if (_propertyPageSite != null) {
                    _propertyPageSite.OnStatusChange();
                }
            }
        }

        protected override void OnLoad(EventArgs e) {
            Type type = typeof(System.Object);
            string assembly = type.Assembly.CodeBase.Replace("mscorlib.dll", "System.Windows.Forms.dll").Replace("file:///", "");
            string assemblyName = System.Reflection.AssemblyName.GetAssemblyName(assembly).FullName;
            Type unsafeNativeMethods = Type.GetType(System.Reflection.Assembly.CreateQualifiedName(assemblyName, "System.Windows.Forms.UnsafeNativeMethods"));
            System.Reflection.MethodInfo methodInfo = unsafeNativeMethods.GetNestedType("IOleObject").GetMethod("GetClientSite");
            _propertyPageSite = methodInfo.Invoke(this, null) as Microsoft.Office.Interop.Outlook.PropertyPageSite;
        }

        public void Apply() {
            Properties.Settings.Default.WaitingTime = numericUpDownWaitingTime.Value;
            Properties.Settings.Default.Save();
        }

        public bool Dirty {
            get {
                return !numericUpDownWaitingTime.Value.Equals(Properties.Settings.Default.WaitingTime);
            }
        }

        public void GetPageInfo(ref string HelpFile, ref int HelpContext) {
            // To Specify HelpFile
        }
    }
}