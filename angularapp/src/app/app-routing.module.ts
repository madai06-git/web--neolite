import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { EmpleadosComponent } from './empleados/empleados.component';
import { AltaEmpleadoComponent } from './empleados/alta-empleado/alta-empleado.component';
import { VerEmpleadosComponent } from './empleados/ver-empleados/ver-empleados.component';
import { ReparacionesComponent } from './reparaciones/reparaciones.component';
import { OpcionesTrabajoComponent } from './opciones-trabajo/opciones-trabajo.component';
import { ReportesComponent } from './reportes/reportes.component'
import { ClienteVentaComponent } from './cliente-venta/cliente-venta.component';
import { InventarioMaterialesComponent } from './inventario-materiales/inventario-materiales.component';

//import { OpcionesTrabajoComponent } from './opciones-trabajo/opciones-trabajo.component'
const routes: Routes = [
  { path: '', component: InicioComponent },
  {
    path: 'empleados',
    component: EmpleadosComponent,
    children: [
      { path: 'alta-empleado', component: AltaEmpleadoComponent },
      { path: 'ver-empleados', component: VerEmpleadosComponent },
    ]
  },
  { path: 'reparaciones', component: ReparacionesComponent },
  { path: 'opciones-trabajo', component: OpcionesTrabajoComponent },
  { path: 'cliente-venta', component: ClienteVentaComponent },
  { path: 'inventario-materiales', component: InventarioMaterialesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
