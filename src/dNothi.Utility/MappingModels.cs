using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
    public class MappingModels
    {
        public static output MapModel<input, output>(input inputModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<input, output>() );
            var mapper = new Mapper(config);
           
            return mapper.Map<output>(inputModel); 
        }
           
    }
}
