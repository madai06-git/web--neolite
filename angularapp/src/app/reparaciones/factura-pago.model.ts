// factura-pago.model.ts
export class FacturaPago {
  constructor(
    public FechaFacturacion: Date,
    public MontoTotal: number,
    public OrdenID: number
  ) { }
}
