using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDAMM_RA
{
    class GlobalServParamSingleton
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

        //Начальный размер оси Х
        public int XAxisMin = 0;
        public int XAxisMax = 51;

        //Текущий размер оси Х
        public int CurrentXAxisMin = 0;
        public int CurrentXAxisMax = 51;

        // Устанавливаем по умолчанию интервал по оси Y
        public int YAxisMin = -50;
        public int YAxisMax = 50;

        private static readonly GlobalServParamSingleton instance = new GlobalServParamSingleton();

        public static GlobalServParamSingleton Instance
        {
            get { return instance; }
        }

        /// защищённый конструктор нужен, чтобы предотвратить создание экземпляра класса Singleton
        protected GlobalServParamSingleton() 
        { }
    }
}
