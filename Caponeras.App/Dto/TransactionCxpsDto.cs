using Caponeras.Data.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Caponeras.App.Dto;

public class TransactionCxpsDto : INotifyPropertyChanged
{
    private int _idtransactionCxp;
    private int _tipoOrigen;
    private int _idOrigen;
    private int? _idTercero;
    private DateTime? _fechaEmision;
    private DateTime? _fechaVencimiento;
    private decimal _montoTotal;
    private decimal _saldoPendiente;
    private EstadoCxp _estado;
    private DateTime? _createdAt;
    private DateTime? _updatedAt;
    private int? _createdBy;
    private int? _updatedBy;

    private IList<TransactionDetailCxpsDto> _transactionDetailCxps;

    public event PropertyChangedEventHandler PropertyChanged;

    public TransactionCxpsDto()
    {
        _transactionDetailCxps = new List<TransactionDetailCxpsDto>();
    }

  public TransactionCxpsDto(TransactionCxps entity)
    {
        if (entity == null)
        {
            _transactionDetailCxps = new List<TransactionDetailCxpsDto>();
            return;
        }

        _idtransactionCxp = entity.IdtransactionCxp;
        _tipoOrigen = entity.TipoOrigen;
        _idOrigen = entity.IdOrigen;
        _idTercero = entity.IdTercero;
        _fechaEmision = entity.FechaEmision;
        _fechaVencimiento = entity.FechaVencimiento;
        _montoTotal = entity.MontoTotal;
        _saldoPendiente = entity.SaldoPendiente;
        _estado = entity.Estado;
        _createdAt = entity.CreatedAt;
        _updatedAt = entity.UpdatedAt;
        _createdBy = entity.CreatedBy;
        _updatedBy = entity.UpdatedBy;

        // 🔄 Mapeo de la lista de detalles
        _transactionDetailCxps = new List<TransactionDetailCxpsDto>();

        if (entity.TransactionDetailCxps != null)
        {
            foreach (var det in entity.TransactionDetailCxps)
            {
                _transactionDetailCxps.Add(new TransactionDetailCxpsDto(det));
            }
        }
    }

    // 🔄 Método inverso: DTO → Modelo EF
    public TransactionCxps ToEntity()
    {
        var entity = new TransactionCxps
        {
            IdtransactionCxp = this.IdtransactionCxp,
            TipoOrigen = this.TipoOrigen,
            IdOrigen = this.IdOrigen,
            IdTercero = this.IdTercero,
            FechaEmision = this.FechaEmision,
            FechaVencimiento = this.FechaVencimiento,
            MontoTotal = this.MontoTotal,
            SaldoPendiente = this.SaldoPendiente,
            Estado = this.Estado,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
            CreatedBy = this.CreatedBy,
            UpdatedBy = this.UpdatedBy,
            TransactionDetailCxps = new List<TransactionDetailCxps>()
        };

        // 🔄 Mapeo inverso de detalles
        if (this.TransactionDetailCxps != null)
        {
            foreach (var detDto in this.TransactionDetailCxps)
            {
                entity.TransactionDetailCxps.Add(detDto.ToEntity());
            }
        }

        return entity;
    }

    public int IdtransactionCxp
    {
        get => _idtransactionCxp;
        set => SetField(ref _idtransactionCxp, value);
    }

    public int TipoOrigen
    {
        get => _tipoOrigen;
        set => SetField(ref _tipoOrigen, value);
    }

    public int IdOrigen
    {
        get => _idOrigen;
        set => SetField(ref _idOrigen, value);
    }

    public int? IdTercero
    {
        get => _idTercero;
        set => SetField(ref _idTercero, value);
    }

    public DateTime? FechaEmision
    {
        get => _fechaEmision;
        set => SetField(ref _fechaEmision, value);
    }

    public DateTime? FechaVencimiento
    {
        get => _fechaVencimiento;
        set => SetField(ref _fechaVencimiento, value);
    }

    public decimal MontoTotal
    {
        get => _montoTotal;
        set => SetField(ref _montoTotal, value);
    }

    public decimal SaldoPendiente
    {
        get => _saldoPendiente;
        set => SetField(ref _saldoPendiente, value);
    }

    public EstadoCxp Estado
    {
        get => _estado;
        set => SetField(ref _estado, value);
    }

    public DateTime? CreatedAt
    {
        get => _createdAt;
        set => SetField(ref _createdAt, value);
    }

    public DateTime? UpdatedAt
    {
        get => _updatedAt;
        set => SetField(ref _updatedAt, value);
    }

    public int? CreatedBy
    {
        get => _createdBy;
        set => SetField(ref _createdBy, value);
    }

    public int? UpdatedBy
    {
        get => _updatedBy;
        set => SetField(ref _updatedBy, value);
    }

    public IList<TransactionDetailCxpsDto> TransactionDetailCxps
    {
        get => _transactionDetailCxps;
        set => SetField(ref _transactionDetailCxps, value);
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}