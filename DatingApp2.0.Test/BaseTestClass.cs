using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp2._0.Test
{
    public abstract class BaseTestClass<T>
        where T : class
    {
        protected BaseTestClass()
        {
            SetUpAutoMocker();
            Target = autoMocker.CreateInstance<T>();
        }

        protected T Target { get; set; }

        protected AutoMocker autoMocker { get; private set; } = new AutoMocker();

        protected virtual void SetUpAutoMocker()
        {

        }
    }
}
