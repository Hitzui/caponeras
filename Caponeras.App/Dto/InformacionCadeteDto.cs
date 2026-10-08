namespace Caponeras.App.Dto;

public record InformacionCadeteDto(
    ConductoresDto Cadete,
    ConductorLicenciasDto? Licencia,
    ConductorIdentificacionsDto? Identificacion
);