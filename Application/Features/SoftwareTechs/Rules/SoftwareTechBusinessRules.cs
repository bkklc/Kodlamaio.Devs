using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareTechs.Rules;

public class SoftwareTechBusinessRules
{
    private readonly ISoftwareTechRepository _softwareRepository;

    public SoftwareTechBusinessRules(ISoftwareTechRepository softwareRepository)
    {
        _softwareRepository = softwareRepository;
    }

    public async Task SoftwareTechNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<SoftwareTech> result = await _softwareRepository.GetListAsync((b) => b.Name == name);
        if (result.Items.Any()) throw new BusinessException("ProgrammingLanguage name exists.");
    }
    public void SoftwareTechShouldExistWhenRequested(Domain.Entities.SoftwareTech softwareTech)
    {
        if (softwareTech == null) throw new BusinessException("Requested brand does not exist");


    }
}