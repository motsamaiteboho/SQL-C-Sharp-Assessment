using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	internal sealed class BetService : IBetService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;
		public BetService(IRepositoryManager repository,
			ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}
		public IEnumerable<BetDto> GetAllBets(Guid spinId,bool trackChanges)
		{
			var bets = _repository.Bet.GetAllBets(spinId, trackChanges);

			var betsDto = _mapper.Map<IEnumerable<BetDto>>(bets);

			return betsDto;
		}

		public BetDto GetBet(Guid id,Guid spinId, bool trackChanges)
		{
			var spin = _repository.Spin.GetSpin(spinId,trackChanges);
			if (spin is null)
				throw new SpinNotFoundException(spinId);
			
			var bet = _repository.Bet.GetBet(id,spinId, trackChanges);
			if (bet is null) 
				throw new BetNotFoundException(id);

			var companyDto = _mapper.Map<BetDto>(bet); 
			return companyDto;
		}
	}
}
