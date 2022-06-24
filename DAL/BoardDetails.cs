using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    internal class BoardDetails
    {
        private Dictionary<Guid, Column> columns;
        private Dictionary<Guid, Task> tasks;
        private Dictionary<Guid, List<Guid>> columnTasks;
    }
}
