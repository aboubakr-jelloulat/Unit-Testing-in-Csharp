using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollService
{
    public interface IZoneService
    {
        bool IsDangerZone(string dutyStation);
    }
}
