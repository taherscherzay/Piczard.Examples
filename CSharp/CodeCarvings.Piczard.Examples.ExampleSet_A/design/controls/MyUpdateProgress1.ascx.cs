﻿/*
 * Piczard Examples | ExampleSet -A- C#
 * Copyright 2011-2012 Sergio Turolla - All Rights Reserved.
 * Author: Sergio Turolla
 * <codecarvings.com>
 *  
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF 
 * ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
 * TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT 
 * SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR 
 * ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN 
 * ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
 * OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class design_controls_MyUpdateProgress1 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string AssociatedUpdatePanelID
    {
        get
        {
            return this.UpdateProgress1.AssociatedUpdatePanelID;
        }
        set
        {
            this.UpdateProgress1.AssociatedUpdatePanelID = value;
        }
    }
}
