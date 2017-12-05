namespace ABB.CDS.Domain.Core.Stack.Model
{
    using SharedKernel;

    public class ButtLapCore : Core<LimbWithAirGap, Yoke>
    {
        public ButtLapCore(LimbWithAirGap[] columns, Yoke[] yokes)
            : base(columns, yokes)
        {
        }
    }
}
