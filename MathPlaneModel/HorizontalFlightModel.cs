using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlaneModel
{
    class HorizontalFlightModel : IAircraftModel
    {
        List<string> simTypes = new List<string>()
        {
            "Runge-Kutti second dimention with correction",
            "Runge-Kutti second dimention",
            "Eiler"
        };

        DifferentialMeanings d;
        IntegralMeanings S;
        Forses F;
        Moments M;
        Coefficient C;
        LinearizedCoefficient c;
        Overload N;
        Controls del;
        Statics s;
        
        Modeling modeling;
        Integrating integ;

        //Контейнеры диф и инт значений для передачи на интегрирование
        Double[] X;
        Double[] X0;
        Double[] Y;

        double dt = 0.01;

        /// <summary>
        /// Set initial values
        /// </summary>
        public void SetInitialValues()
        {
            d = new DifferentialMeanings();
            S = new IntegralMeanings();
            F = new Forses();
            M = new Moments();
            C = new Coefficient();
            c = new LinearizedCoefficient();
            N = new Overload();
            del = new Controls();
            s = new Statics();

            Type type = typeof(DifferentialMeanings);
            int modelDimention = type.GetProperties().Length;

            X = new Double[modelDimention];
            X0 = new Double[modelDimention];
            Y = new Double[modelDimention];

            modeling = new Modeling(modelDimention);
            integ = new Integrating();

            modeling.bal(S, C, del, s);
            modeling.setRealParamValuesFromIncrements(S, d, del);
            modeling.calcLinearCoef(S, del, c, s);
        }

        /// <summary>
        /// Processing step
        /// </summary>
        private void SimByRungeKuttiWithCorrectionIntegration()
        {
            Y = modeling.getIntegratedValuesIncrements(S);
            modeling.dynLinear(d, S, c, del, s);
            X = modeling.getDiffValuesIncrements(d);
            X0 = integ.rungeKytti_withCor_step1(dt, X0, Y);
            integ.rungeKytti_withCor_step1(dt, X0, Y);
            modeling.returnIntegratedValuesIncrements(S, Y);

            Y = modeling.getIntegratedValuesIncrements(S);
            modeling.dynLinear(d, S, c, del, s);
            X = modeling.getDiffValuesIncrements(d);
            integ.rungeKytti_withCor_step2(dt, X, Y, X0);
            modeling.returnIntegratedValuesIncrements(S, Y);
            modeling.setRealParamValuesFromIncrements(S, d, del);
        }

        private void SimByRungeIntegration()
        {
            Y = modeling.getIntegratedValuesIncrements(S);
            modeling.dynLinear(d, S, c, del, s);
            X = modeling.getDiffValuesIncrements(d);
            X0 = integ.rungeKytti_step1(dt, X, Y, X0);
            integ.rungeKytti_step1(dt, X, Y, X0);
            modeling.returnIntegratedValuesIncrements(S, Y);

            Y = modeling.getIntegratedValuesIncrements(S);
            modeling.dynLinear(d, S, c, del, s);
            X = modeling.getDiffValuesIncrements(d);
            integ.rungeKytti_step2(dt, X, Y, X0);
            modeling.returnIntegratedValuesIncrements(S, Y);
            modeling.setRealParamValuesFromIncrements(S, d, del);
        }

        private void SimByEilerIntegration()
        {
            Y = modeling.getIntegratedValuesIncrements(S);
            modeling.dynLinear(d, S, c, del, s);
            X = modeling.getDiffValuesIncrements(d);
            integ.eiler(dt, X, Y);
            modeling.returnIntegratedValuesIncrements(S, Y);
            modeling.setRealParamValuesFromIncrements(S, d, del);
        }


        public void Sim()
        {
            throw new NotImplementedException();
        }

        public void SetSimType(string type)
        {
            throw new NotImplementedException();
        }

        public void SetControls()
        {
            throw new NotImplementedException();
        }

        public void GetControls()
        {
            throw new NotImplementedException();
        }

        public void SetDt(double extDt)
        {
            dt = extDt;
        }
    }
}
