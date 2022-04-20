using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace Chart
{
    public partial class ChartControl : System.Web.UI.Page
    {
        BLL_EmployeeDetails objEmployees = new BLL_EmployeeDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStates();
            }
        }

        void GetStates()
        {
            try
            {
                DataTable dtStates = objEmployees.GetStates();

                if (dtStates.Rows.Count > 0)
                {
                    ddlStates.Items.Clear();
                    ddlStates.DataSource = dtStates;
                    ddlStates.DataTextField = "state";
                    ddlStates.DataValueField = "state";
                    ddlStates.Items.Add(new ListItem("Select State", "", true));
                    ddlStates.Items.Add(new ListItem("ALL", "ALL", true));
                    ddlStates.DataBind();
                }
                else
                {
                    ddlStates.Items.Clear();
                    ddlStates.Items.Add(new ListItem("Select State", "", true));
                    ddlStates.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        void GetEmployeeDetails()
        {
            try
            {
                if (string.IsNullOrEmpty(ddlStates.SelectedValue))
                {
                    divChart.Visible = false;
                    ddlStates.Focus();
                    lblMessage.Text = "Select a state to generate chart.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblMessage.Text = string.Empty;
                    DataTable dtEmployees = objEmployees.GetEmployeeDetails(ddlStates.SelectedValue);

                    if (dtEmployees.Rows.Count > 0)
                    {
                        divChart.Visible = true;
                        myChart.DataSource = dtEmployees;
                        myChart.Series[0].ChartType = (SeriesChartType)int.Parse(rblChartType.SelectedItem.Value);

                        myChart.Series[0].XValueMember = "State";
                        myChart.Series[0].YValueMembers = "TotalStaff";
                        myChart.Series[0].IsValueShownAsLabel = true;
                        myChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                        myChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                        myChart.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnShowChart_Click(object sender, EventArgs e)
        {
            GetEmployeeDetails();
        }

    }
}