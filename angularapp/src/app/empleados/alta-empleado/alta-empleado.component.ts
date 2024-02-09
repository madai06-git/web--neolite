
import { Component,OnInit } from '@angular/core';
//import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { EmpleadoService } from 'src/app/empleado.service';



@Component({
  selector: 'app-alta-empleado',
  templateUrl: './alta-empleado.component.html',
  styleUrls: ['./alta-empleado.component.css']

})
export class AltaEmpleadoComponent {
 // private apiUrl = 'https://localhost:7216/api/Empleadoes';
 // constructor(private http: HttpClient) {}
  empleado = {

    "empleadoId": 0,
    "nombre": "",
    "rol": "",
    "contacto": "",
    "comision": ""
  };

  constructor(private empleadoService: EmpleadoService) { }

  darDeAltaEmpleado() {
    this.empleadoService.darDeAltaEmpleado(this.empleado)
      .subscribe(
        (respuesta: any) => {
          alert('Empleado dado de alta:');
          // Puedes hacer algo después de dar de alta el empleado, como navegar a otra página.
        },
        (error: any) => {
          alert('Error al dar de alta al empleado:' + error.message);
          console.error('Error al dar de alta al empleado:', error);

        }
      );

  }


}
