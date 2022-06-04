using System;

namespace PollingSystem.Entities.Base
{
    //class abstract т.к. не создаем инстансы
    //идентификатор
    public abstract class Identity
    {
        public Guid Id { get; set; }
    }
}
