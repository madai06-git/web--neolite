import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { EmpleadosComponent } from './empleados/empleados.component';
import { AltaEmpleadoComponent } from './empleados/alta-empleado/alta-empleado.component';
import { VerEmpleadosComponent } from './empleados/ver-empleados/ver-empleados.component';
import { ReparacionesComponent } from './reparaciones/reparaciones.component';


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
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
