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
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';
import { ClienteVentaComponent } from './cliente-venta/cliente-venta.component';
import { ReactiveFormsModule } from '@angular/forms'; // Agrega esta importación
import { CommonModule } from '@angular/common';
import { InventarioMaterialesModule } from './inventario-materiales/inventario-materiales.module';


@NgModule({
  declarations: [
    AppComponent,
    InicioComponent,
    AltaEmpleadoComponent,
    VerEmpleadosComponent,
    EmpleadosComponent,
    ClienteVentaComponent,
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
    CommonModule,
    ReactiveFormsModule,
    InventarioMaterialesModule,
   // ClienteVentaModule,
  //  OpcionesTrabajoModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
