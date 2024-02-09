// orden-trabajo.model.ts
export class OrdenTrabajo {
  constructor(
    public FechaSolicitud: Date,
    public FechaEntregaEstimada: Date,
    public Estado: string,
    public ClienteID: number
  ) { }
}
