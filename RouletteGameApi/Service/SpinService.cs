using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	internal sealed class SpinService : ISpinService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public SpinService(IRepositoryManager repository, 
			ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
         }

		public IEnumerable<SpinDto> GetAllSpins(bool trackChanges)
		{
			var spins = _repository.Spin.GetAllSpins(trackChanges);

			var spinsDto = _mapper.Map<IEnumerable<SpinDto>>(spins);

			return spinsDto;
		}

        public SpinDto GetSpin(Guid spinId,bool trackChanges)
        {
			var spin = _repository.Spin.GetSpin(spinId, trackChanges);
			if (spin is null)
				throw new  SpinNotFoundException(spinId);

			var sipnDto = _mapper.Map<SpinDto>(spin);

			return sipnDto;
        }
    }
}

