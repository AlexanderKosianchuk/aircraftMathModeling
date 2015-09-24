using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using ZedGraph;
using MathPlaneModel;

namespace FDAMM_RA
{
    public partial class GraphicsForm : DockContent
    {

        //делегат для анчека галочки в списке при закрытии окна с графиком путем нажатия крестика
        //с передачей номера елемента в CheckedListBox
        public GraphicsListForm.DelegateCheckedListBox2SetItemChecked SetItemChecked;
       
        PointPairList list;
        public GraphPane pane;
        LineItem Curve;
        GlobalServParam p;
        Statics s;
        //Номер элемента CheckedListBox из Form1 для Uncheck
        public int iNumItemToUncheck = 0;

        int iCurrentScalePosition = 0;

        public bool chartAutoScaleEna = true;

        public GraphicsForm()
        {
            InitializeComponent();

            list = new PointPairList();
            p = new GlobalServParam();
            s = new Statics();
            pane = zedGraphControl1.GraphPane;

        }

        /// <summary>
        /// Initialize chart pane in created window
        /// </summary>
        /// <param name="sGraphName">Название графика</param>
        /// <param name="sXAxisTitle">Название оси Х</param>
        /// <param name="sYAxisTitle">Название оси Y</param>
        /// <param name="sCuveName">Название кривой</param>
        /// <param name="iYAxisMinScale">Минимально допустимое значение оси Y</param>
        /// <param name="iYAxisMaxScale">Максимально допустимое значение оси Y</param>
        public void CreateChart(String sGraphName, String sXAxisTitle, String sYAxisTitle, String sCuveName,
            Int32 iYAxisMinScale, Int32 iYAxisMaxScale)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();

            zedGraphControl1.GraphPane.Title.Text = sGraphName;
            zedGraphControl1.GraphPane.XAxis.Title.Text = sXAxisTitle;
            zedGraphControl1.GraphPane.YAxis.Title.Text = sYAxisTitle;

            // Generate a curve 
            Curve = zedGraphControl1.GraphPane.AddCurve(sCuveName, list, Color.Red, SymbolType.None);

            // Add gridlines to the plot, and make them gray
            zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;
            zedGraphControl1.GraphPane.XAxis.MajorGrid.Color = Color.LightGray;
            zedGraphControl1.GraphPane.YAxis.MajorGrid.Color = Color.LightGray;

            pane.XAxis.Scale.Min = iCurrentScalePosition;
            pane.XAxis.Scale.Max = iCurrentScalePosition + p.XAxisMax;

            // Устанавливаем интересующий нас интервал по оси Y
            if (iYAxisMinScale == 0)
            {
                pane.YAxis.Scale.Min = p.YAxisMin;
            }
            else 
            {
                pane.YAxis.Scale.Min = iYAxisMinScale;           
            }

            if (iYAxisMaxScale == 0)
            {
                pane.YAxis.Scale.Max = p.YAxisMax;
            }
            else
            {
                pane.YAxis.Scale.Max = iYAxisMaxScale;
            }

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphControl1.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();

        }

        /// <summary>
        /// Рисуем график, путем получения точек(накапливаем до определенного лимита, 
        /// а потом выводим только заданый интервал, стирая хвост)
        /// </summary>
        /// <param name="X">Координата Х</param>
        /// <param name="Y">Координата Y</param>
        public void DrawChart(Double X, Double Y)
        {
            if (chartAutoScaleEna)
            {
                if (Y >= pane.YAxis.Scale.Max)
                {
                    pane.YAxis.Scale.Max += 50;                
                }
                else if (Y <= pane.YAxis.Scale.Min)
                {
                    pane.YAxis.Scale.Min -= 50; 
                }
            }

            list.Add(X, Y);

            pane.XAxis.Scale.Min = list[0].X;
            pane.XAxis.Scale.Max = list[0].X + p.XAxisMax;


            if (list.Count > p.PointMaxCount)
            {
                list.RemoveAt(0);

                // Устанавливаем интересующий нас интервал по оси X
                pane.XAxis.Scale.Min += s.dt;
                pane.XAxis.Scale.Max += s.dt;
            }

            zedGraphControl1.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();
        
        }

        //Очистка графика(на случай нажатия "Сброс" без закрытия графика)
        public void ClearChart()
        {
            try
            {
                Curve.Clear();
            }
            catch
            {
                //значит сброс нажат при закрытом графике            
            }
            zedGraphControl1.Invalidate();
        }

        private void GraphicsForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.SetItemChecked(iNumItemToUncheck, false);
        }
    }
}
