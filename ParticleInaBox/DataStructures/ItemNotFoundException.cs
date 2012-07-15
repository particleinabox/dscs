using System;
using System.Runtime.Serialization;
namespace ParticleInaBox
{
    namespace DataStructures
    {
        [Serializable]
        public class ItemNotFoundException : System.Exception
        {
            public ItemNotFoundException(object item)
                : base(item.ToString())
            {
            }

            public ItemNotFoundException()
            {
                    
            }

            public ItemNotFoundException(string message) 
                : base(message)
            {
            
            }

            public ItemNotFoundException(string message, Exception ex)
                : base(message, ex)
            {

            }

            protected ItemNotFoundException(SerializationInfo info, StreamingContext context) 
                : base(info, context)
            {
            
            }
        }
    }
}