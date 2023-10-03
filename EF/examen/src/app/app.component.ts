import { Component } from '@angular/core';
import { environment} from '../environment/enviroment';
import { CatalogoPersona } from 'src/Models/persona-model';
import {PersonaService} from 'src/Services/personas.service'
import { FormsModule } from '@angular/forms';
declare var $ : any;
import Swal from 'sweetalert2'
import * as bootstrap from 'bootstrap'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'examen';
  listPersona : CatalogoPersona[] = [];

  idlast : Number = 0;
  num: Number = 1;
  id:Number =0;
  nombre:string="";
  direccion:string="";
  telefono:string="";
  email:string="";
  titleModal : string = "";
  add : boolean = false;
  sendPersona : CatalogoPersona;

  constructor(public personaService : PersonaService) { 

    this.sendPersona = new CatalogoPersona();
  }

  ngOnInit(): void {
    this.getPersonas();
  }

  getPersonas(){
   this.personaService.getPersona().subscribe((data)=>{
      this.listPersona = data;
      for(let i=0; i<this.listPersona.length; i++){
        this.idlast = this.listPersona[i].id;
      }

    });
  }

  AddModule(){
    this.titleModal= "Agregar Persona";
    this.add = true;
    $('#modalAgregarFormulario').modal("show");
  }

  UpdateModule(id : Number){
    this.id = id;
    this.titleModal= "Actualizar Persona";
    let update = this.listPersona.filter(elemento => elemento.id = id);
    this.nombre=update[0].nombre;
    this.direccion = update[0].direccion;
    this.telefono =update[0].telefono;
    this.email =update[0].email;
    $('#modalAgregarFormulario').modal("show");
  }

  Delete(id :Number){
  Swal.fire({
    title: 'Esta seguro de eliminar el registro?',
    showCancelButton: true,
    confirmButtonText: 'Si',
  }).then((result) => {
    /* Read more about isConfirmed, isDenied below */
    if (result.isConfirmed) {
   
      this.personaService.deletePersona(id).subscribe((data)=>{
        this.listPersona = data;
      for(let i=0; i<this.listPersona.length; i++){
         this.idlast = this.listPersona[i].id;
        }
 
        this.Cancelar();
        Swal.fire(
          'Eliminación con Exito',
          '',
          'success'
        )
     });
    } 
  })
}

Adddata(){
    if(this.nombre !=""){
      if(this.direccion != ""){
        if(this.telefono != ""){
            if(this.email != ""){

              let emailRegex = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
              if (this.email.match(emailRegex)){
                let id : Number;
                this.idlast  
              
                this.sendPersona.id = this.idlast;
                this.sendPersona.nombre = this.nombre;
                this.sendPersona.direccion = this.direccion;
                this.sendPersona.telefono = this.telefono;
                this.sendPersona.email = this.email;
                if(this.add){
                  this.personaService.addPersona(this.sendPersona).subscribe((data)=>{
                    this.listPersona = data;
                  for(let i=0; i<this.listPersona.length; i++){
                     this.idlast = this.listPersona[i].id;
                    }
                    this.Cancelar();
                    Swal.fire(
                      'Creación con Exito',
                      '',
                      'success'
                    )
                 });
                }else{
                  this.sendPersona.id = this.id;
                  this.personaService.updatePersona(this.sendPersona).subscribe((data)=>{
                    this.listPersona = data;
                  for(let i=0; i<this.listPersona.length; i++){
                     this.idlast = this.listPersona[i].id;
                    }
             
                    this.Cancelar();
                    Swal.fire(
                      'Actualización con Exito',
                      '',
                      'success'
                    )
                 });
                }
              }else{
                Swal.fire('Debe colocar un email valido');
              }
            }else{
              Swal.fire('Debe colocar un correo');
            }
        }else{
          Swal.fire('Debe colocar un número de teléfono');
        }
      }else{
        Swal.fire('Debe colocar una direccion');
      }
    }else{
      Swal.fire('Debe colocar un nombre');
    }
  }

  Cancelar(){
    this.add = false;
    this.nombre="";
    this.direccion = "";
    this.telefono ="";
    this.email ="";
    $('#modalAgregarFormulario').modal("hide");
  }
}
