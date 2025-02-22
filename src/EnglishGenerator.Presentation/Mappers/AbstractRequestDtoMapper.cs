using EnglishGenerator.Core.Dtos;
using EnglishGenerator.Presentation.WebApi.ApiModels;

namespace EnglishGenerator.Presentation.Mappers;

public abstract class AbstractRequestDtoMapper<TAbstractRequest, TAbstractDto>
    where TAbstractRequest : AbstractRequest
    where TAbstractDto : AbstractDto
{
    public abstract TAbstractDto MapToDto(TAbstractRequest request);
}