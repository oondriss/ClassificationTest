namespace ClassificationTest.DTO
{
    class NeuronInstanceData
    {
        public NeuronInstanceData(double t1, double t2, double t3, bool a)
        {
            T1 = t1;
            T2 = t2;
            T3 = t3;
            A = a ? 1 : 0;
        }
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double T3 { get; set; }
        public int A { get; set; }

    }
}
