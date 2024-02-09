// detalle-reparacion.model.ts
export class DetalleReparacion {
  constructor(
    public DescripcionProblema: string,
    public MaterialesNecesarios: string,
    public CostoEstimado: number,
    public OrdenID: number
  ) { }
}
