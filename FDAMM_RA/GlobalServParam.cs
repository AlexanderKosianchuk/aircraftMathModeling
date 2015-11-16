using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDAMM_RA
{
    class GlobalServParam
    {
        /// <summary>
        ///Максимальное количество отображаемых записей в таблице
        /// </summary>
        public int RowMaxCount = 250;
        public int PointMaxCount = 490;

        /// <summary>
        /// Текущее количество строчек в таблице
        /// </summary>
        public int rowNum = 0;

        public static int modelDimention = 12;
        //public static int polnuy_razmer = 53;

        //Начальный размер оси Х
        public int XAxisMin = 0;
        public int XAxisMax = 51;

        //Текущий размер оси Х
        public int CurrentXAxisMin = 0;
        public int CurrentXAxisMax = 51;

        // Устанавливаем по умолчанию интервал по оси Y
        public int YAxisMin = -50;
        public int YAxisMax = 50;
    }
}
