import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InicioComponent } from './inicio/inicio.component';
import { AltaEmpleadoComponent } from './empleados/alta-empleado/alta-empleado.component';
import { VerEmpleadosComponent } from './empleados/ver-empleados/ver-empleados.component';
import { EmpleadosComponent } from './empleados/empleados.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card'
import { FormsModule } from '@angular/forms';
//import { ReparacionesComponent } from './reparaciones/reparaciones.component';
//import { ContactoComponent } from './contacto/contacto.component';
//import { OpcionesTrabajoComponent } from './opciones-trabajo/opciones-trabajo.component';


//import { OpcionesTrabajoModule } from './opciones-trabajo/opciones-trabajo.module'; // Ajusta la ruta según la ubicación de tu módulo


@NgModule({
  declarations: [
    AppComponent,
    InicioComponent,
    AltaEmpleadoComponent,
    VerEmpleadosComponent,
    EmpleadosComponent,
    //OpcionesTrabajoComponent
    //ReparacionesComponent
  //  ContactoComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatListModule,
    MatCardModule,
    FormsModule,
  //  OpcionesTrabajoModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
