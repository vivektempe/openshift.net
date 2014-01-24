﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Uhuru.Openshift.Runtime;

namespace Uhuru.Openshift.Cmdlets
{
    [Cmdlet("OO", "Activate")]
    public class OO_Activate : System.Management.Automation.Cmdlet 
    {
        [Parameter]
        public string WithAppUuid;

        [Parameter]
        public string WithAppName;

        [Parameter]
        public string WithContainerUuid;

        [Parameter]
        public string WithContainerName;

        [Parameter]
        public string WithNamespace;

        [Parameter]
        public string WithRequestId;

        [Parameter]
        public string CartName;

        [Parameter]
        public string ComponentName;

        [Parameter]
        public string WithSoftwareVersion;

        [Parameter]
        public string CartridgeVendor;

        [Parameter]
        public string DeploymentId;

        protected override void ProcessRecord()
        {
            ReturnStatus status = new ReturnStatus();
            ApplicationContainer container = new ApplicationContainer(WithAppUuid, WithContainerUuid, null, WithAppName,
                            WithContainerName, WithNamespace, null, null, null);
            try
            {
                Dictionary<string, object> options = new Dictionary<string,object>();
                options["deployment_id"] = DeploymentId;
                status.Output = container.Activate(options);
                status.ExitCode = 0;
            }
            catch (Exception ex)
            {
                status.Output = ex.ToString();
                status.ExitCode = 1;
            }
            this.WriteObject(status);
        }
    }
}