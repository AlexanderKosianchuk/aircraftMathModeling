namespace MathPlaneModel
{
    interface IAircraftModel
    {
        void SetInitialValues();
        void Sim();
        void GetSimTypes();
        void SetSimType(string type);
        void SetControls();
        void GetControls();
        void SetDt();
    }
}