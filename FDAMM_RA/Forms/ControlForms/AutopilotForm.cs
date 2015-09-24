using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using MathPlaneModel;

namespace FDAMM_RA
{
    public partial class AutopilotForm : DockContent
    {
        MainForm mForm;
        IntegralMeanings S;
        Statics s;
        LinearizedCoefficient c;
        Controls del;
        Statics scoe;
        Modeling modeling = new Modeling();


        public AutopilotForm(MainForm MainForm)
        {
            mForm = MainForm;
            S = mForm.S;
            s = mForm.s;
            c = mForm.c;
            del = mForm.del;
            scoe = mForm.s;
            InitializeComponent();
        }

        private void AutopilotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mForm.toolStripButton7_Autopilot.Checked = false;
        }

        /// <summary>
        /// target height
        /// </summary>
        public double tH;
        /// <summary>
        /// delta height
        /// </summary>
        public double delH;
        /// <summary>
        /// coef near delta H
        /// </summary>
        public double kH;
        /// <summary>
        /// coef near dH/dt
        /// </summary>
        public double kdH;
        /// <summary>
        /// connection maneure execution to simulation
        /// </summary>
        public string maneur;

        double [] a = new double[5];
        bool calcComplt;
        bool unreacheable;
        double value;
        double calcStep = 0.001;
        double topLevelStability = 1.5;
        double botLevelStability = 0.5;

        private void calcCoef_kH_kdH()
        {
            calcComplt = false;
            unreacheable = false;

            modeling.calcLinearCoef(S, del, c, s);

            value = 0;
            kdH = 0.01;

            while(!calcComplt)
            {
                kH = kdH * kdH / 4;

                a[0] = 1;
                a[1] = c.c1 + c.c4 + c.c5;
                a[2] = c.c2 + c.c1 * c.c4;
                a[3] = c.c4 * c.c6 * kdH;
                a[4] = c.c3 * c.c4 * c.c6 * kH;

                if ((a[0] < 0) || (a[1] < 0) || (a[2] < 0))
                {
                    calcComplt = true;
                    MessageBox.Show("The result is unreacheble", "Attention");
                }

                value = a[1] * a[2] * a[3] - a[0] * a[3] * a[3] - a[1] * a[1] * a[4];

                if((a[0] > 0) && (a[1] > 0) && (a[2] > 0) && (a[3] > 0) && (a[4] > 0) &&
                    (value > botLevelStability) && (value < topLevelStability))
                {
                    //kdH = kdH;
                    kH = kdH * kdH / 4;
                    calcComplt = true;
                }
                else
                {
                    if (value < botLevelStability)
                    {
                        kdH += calcStep;

                        if (unreacheable)
                        {
                            calcComplt = true;
                            MessageBox.Show("The result is unreacheble","Attention");
                        }
                    }
                    else if (value > topLevelStability)
                    {
                        kdH -= calcStep;
                    }
                    else
                    {
                        //it means !(a[0] > 0) && (a[1] > 0) && (a[2] > 0) && (a[3] > 0) && (a[4] > 0) thus
                        kdH += calcStep * calcStep;
                        //if calculation jump out from this block the result is unreacheble
                        unreacheable = true;
                    }
                }
                  
            }
        }

        private void executeChangeHeightDuringSim_CheckedChanged(object sender, EventArgs e)
        {
            if (this.executeChangeHeightDuringSim.Checked)
            {
                if (this.ManeuversChangeHeightTextBox.Text == "")
                {
                    MessageBox.Show("Enter meanning of delta height", "Attention");
                    this.executeChangeHeightDuringSim.CheckState = CheckState.Unchecked;
                }
                else
                {
                    delH = Convert.ToDouble(this.ManeuversChangeHeightTextBox.Text);
                    tH = S.Yg + delH;
                    if (this.calcCoefTyteComboBox.Text == "analize coef")
                    {
                        if (this.ctrlLawComboBox.Text == "kH*delH + kdH*dH")
                        {
                            calcCoef_kH_kdH();
                            textBox1.Text = Convert.ToString(kH);
                            textBox2.Text = Convert.ToString(kdH);

                            maneur = "change height by kH*delH + kdH*dH";
                        }
                    }
                    else if (this.calcCoefTyteComboBox.Text == "get coef")
                    {
                        if (textBox1.Text == "" || textBox1.Text == "")
                        {
                            MessageBox.Show("Enter kH and kdH", "Attention");
                        }
                        else 
                        {
                            if (this.ctrlLawComboBox.Text == "kH*delH + kdH*dH")
                            {
                                kH = Convert.ToDouble(textBox1.Text);
                                kdH = Convert.ToDouble(textBox2.Text);

                                maneur = "change height by kH*delH + kdH*dH";
                            }

                        }
                    
                    }


                }
            }
        }



    }
}

/*
   /// <summary>


        private void changeHeightManeuver()
        {
            scoe.kH = Convert.ToDouble(textBox1.Text);
            scoe.kWz = Convert.ToDouble(textBox2.Text);

            Double step;

            difH = S.Yg - tH;

            if (Math.Abs(difH) > 100 / (180 / Math.PI))
            {
                step = 1 / (180 / Math.PI);            
            }
            else if ((Math.Abs(difH) < 50 / (180 / Math.PI)) &&
                ((Math.Abs(difH) > 1 / (180 / Math.PI))))
            {
                step = 0.1 / (180 / Math.PI);
            }
            else
            {
                step = 0.01 / (180 / Math.PI);
            }

            cH = S.Yg;
            if (tH != cH || difH != 0)
            {

                if ((-(del.e_rv - scoe.del_e_rvo)) < (difH * scoe.kH + scoe.kWz * S.Wz))
                {
                    //to prevent out of range on the next iteration
                    if (del.e_rv <= (scoe.del_e_rvMIN + (1 / (180 / Math.PI))))
                    {
                        del.e_rv = scoe.del_e_rvMIN;
                    }
                    else
                    {
                        del.e_rv -= step;
                    }
                }
                else if ((-(del.e_rv - scoe.del_e_rvo)) > (difH * scoe.kH + scoe.kWz * S.Wz))
                {
                    if (del.e_rv >= (scoe.del_e_rvMAX - (1 / (180 / Math.PI))))
                    {
                        del.e_rv = scoe.del_e_rvMAX;
                    }
                    else
                    {
                        del.e_rv += step;
                    }
                }

                mForm.avForm.SetControlValues(del);
            }

        
        }

        /// <summary>
        /// time to get stabile coef
        /// </summary>
        double timeLimit = 100;
        double timeElapsed;
        private void calcCoefToChangeHeightr()
        {
            difH = S.Yg - tH;

            cH = S.Yg;
            if (timeElapsed <= timeLimit)
            {
                if (tH != cH || difH != 0)
                {
                    if ((-(del.e_rv - scoe.del_e_rvo)) < (difH * scoe.kH - scoe.kWz * S.Wz))
                    {
                        //to prevent out of range on the next iteration
                        if (del.e_rv <= (scoe.del_e_rvMIN + (1 / (180 / Math.PI))))
                        {
                            del.e_rv = scoe.del_e_rvMIN;
                        }
                        else
                        {
                            del.e_rv -= (1 / (180 / Math.PI));
                        }
                    }
                    else if ((-(del.e_rv - scoe.del_e_rvo)) > (difH * scoe.kH - scoe.kWz * S.Wz))
                    {
                        if (del.e_rv >= (scoe.del_e_rvMAX - (1 / (180 / Math.PI))))
                        {
                            del.e_rv = scoe.del_e_rvMAX;
                        }
                        else
                        {
                            del.e_rv += (1 / (180 / Math.PI));
                        }
                    }

                    mForm.avForm.SetControlValues(del);
                    timeElapsed += scoe.dt;
                }
            }
            else
            {
                scoe.kH += scoe.dt;
                scoe.kWz -= scoe.dt;
                timeElapsed = 0;
                mForm.SetInitialValues();
                del.e_rv = 0;
                mForm.avForm.SetControlValues(del);
            }

        }
*/