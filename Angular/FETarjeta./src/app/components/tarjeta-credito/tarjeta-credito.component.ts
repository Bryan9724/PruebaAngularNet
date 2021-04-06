import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TarjetaService } from 'src/app/services/tarjeta.service';
import { Pipe, PipeTransform } from '@angular/core';
import { stringify } from '@angular/compiler/src/util';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-tarjeta-credito',
  templateUrl: './tarjeta-credito.component.html',
  styleUrls: ['./tarjeta-credito.component.css']
})
export class TarjetaCreditoComponent implements OnInit  {
  listTarjetas: any[] = [];

  form: FormGroup;
  accion = 'Crear una cuenta de ahorros'
  id: number | undefined;
  placeholderDinero= 'Valor inicial';
  tipoOperacion = 0;

  constructor(private fb: FormBuilder, 
    private toastr: ToastrService,
    private _tarjetaService: TarjetaService) { 
    
    this.form = this.fb.group({
      fistName: ['', [Validators.required, Validators.pattern('[A-z]*\\s*')]],
      lastName: ['', [Validators.required, Validators.pattern('[A-z]*\\s*')]],
      brithDate: ['', Validators.required],
      numeroCuenta: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(20), Validators.pattern('^[0-9]*$')]],
      dinero: ['', [Validators.required, Validators.maxLength(7), Validators.minLength(5), Validators.pattern('^[0-9]*$')]],
      password: ['', [Validators.required, Validators.maxLength(4), Validators.minLength(4), Validators.pattern('^[0-9]*$') ]]
    })
  }

  ngOnInit(): void {
    this.obtenerTarjetas();
  }

  obtenerTarjetas(){
    this._tarjetaService.getListTarjetas().subscribe(data => {
      console.log(data);
      this.listTarjetas = data;
    }, error => {
      console.log(error);
    } );
  }

  guardarTarjeta(){

    const client: any ={
      fistName: this.form.get('fistName')?.value,
      lastName: this.form.get('lastName')?.value,
      brithDate: this.form.get('brithDate')?.value
    }
    const Cuenta: any ={
      numeroCuenta: this.form.get('numeroCuenta')?.value
    }
    const CuentaClient: any ={
      cliente: client,
      cuenta: Cuenta,
      passwrod: this.form.get('password')?.value,
      dinero: this.form.get('dinero')?.value  
    }
    if(this.id == undefined){
      
      console.log(CuentaClient);
      this._tarjetaService.saveCuentaCliente(CuentaClient).subscribe(data2 =>{
        this.toastr.success('La Cuenta ha sido registrada con exito!', 'Cuenta registrada');
        this.obtenerTarjetas();
        this.form.reset();
      },error =>{
        this.toastr.error('Error inesperado :( cuenta cliente', 'Error')
        console.log(error);
      });
       
    }else{
      if(this.tipoOperacion == 0){
        CuentaClient.id = this.id;
        console.log(this.id);
        this._tarjetaService.updateDineroCuentaCliente(this.id, CuentaClient, this.tipoOperacion).subscribe(data =>{
          this.toastr.info('Se han consignado $'+ CuentaClient.dinero.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") +' con exito', 'Tarjeta actualizada');
          this.form.reset();
          this.accion = 'Crear una cuenta de ahorros';
          this.id = undefined;
          this.obtenerTarjetas();
          this.form.get('fistName')?.enable({ onlySelf: true });
          this.form.get('lastName')?.enable({ onlySelf: true });
          this.form.get('brithDate')?.enable({ onlySelf: true });
          this.form.get('numeroCuenta')?.enable({ onlySelf: true });
        }, error => {
          console.log(error.error.message);
          this.toastr.error('Error :( ' + error.error.message , 'Error')
        });
      }else if(this.tipoOperacion == 1){
        console.log('Retirar Dinero');
        CuentaClient.id = this.id;
        this._tarjetaService.updateDineroCuentaCliente(this.id, CuentaClient, this.tipoOperacion).subscribe(data =>{
          this.toastr.info('Se ha retirado $' + CuentaClient.dinero.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") + ' con exito', 'Tarjeta actualizada');
          
          this.form.reset();
          this.accion = 'Crear una cuenta de ahorros';
          this.id = undefined;
          this.obtenerTarjetas();
          this.form.get('fistName')?.enable({ onlySelf: true });
          this.form.get('lastName')?.enable({ onlySelf: true });
          this.form.get('brithDate')?.enable({ onlySelf: true });
          this.form.get('numeroCuenta')?.enable({ onlySelf: true });
        }, error => {
          console.log(error.error.message);
          this.toastr.error('Error :( ' + error.error.message , 'Error')
        });
      }else{
        console.log('Consultar Dinero');
        CuentaClient.id = this.id;
        this._tarjetaService.getCuentaClienteid(this.id, CuentaClient.passwrod).subscribe(data =>{
          this.toastr.info('Tu saldo es de $' +  data.dinero.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") , 'Tarjeta actualizada');
          
          this.form.reset();
          this.accion = 'Crear una cuenta de ahorros';
          this.id = undefined;
          this.obtenerTarjetas();
          this.form.get('fistName')?.enable({ onlySelf: true });
          this.form.get('lastName')?.enable({ onlySelf: true });
          this.form.get('brithDate')?.enable({ onlySelf: true });
          this.form.get('numeroCuenta')?.enable({ onlySelf: true });
          this.form.get('dinero')?.enable({ onlySelf: true });
        }, error => {
          console.log(error.error.message);
          this.toastr.error('Error :( ' + error.error.message , 'Error')
        });
      }
    }

    
    
  }

  RetirarDinero(tarjeta: any){
    this.tipoOperacion = 1;
    this.form.get('dinero')?.enable({ onlySelf: true });
    this.accion = 'Retirar dinero';
    this.id = tarjeta.id;
    this.form.patchValue({
      fistName: tarjeta.fistName,
      lastName: tarjeta.lastName,
      brithDate: tarjeta.brithDate,
      numeroCuenta: tarjeta.numeroCuenta,
      dinero: "",
      password: "",
    });
    
    this.form.get('fistName')?.disable({ onlySelf: true });
    this.form.get('lastName')?.disable({ onlySelf: true });
    this.form.get('brithDate')?.disable({ onlySelf: true });
    this.form.get('numeroCuenta')?.disable({ onlySelf: true });
    
    this.placeholderDinero = 'Valor Retirar';

    /*this._tarjetaService.deleteTarjeta(index).subscribe(data => {
      this.toastr.error('La tarjeta fue eliminada con exito', 'Tarjeta eliminada');
      this.obtenerTarjetas();
    }, error => {
      console.log(error);
    })*/
    
  }

  ConsignarDinero(tarjeta: any){
    this.tipoOperacion = 0;
    this.accion = 'Consignar dinero';
    this.id = tarjeta.id;
    this.form.patchValue({
      fistName: tarjeta.fistName,
      lastName: tarjeta.lastName,
      brithDate: tarjeta.brithDate,
      numeroCuenta: tarjeta.numeroCuenta,
      dinero: "",
      password: "",
    });
    this.form.get('dinero')?.enable({ onlySelf: true });
    this.form.get('fistName')?.disable({ onlySelf: true });
    this.form.get('lastName')?.disable({ onlySelf: true });
    this.form.get('brithDate')?.disable({ onlySelf: true });
    this.form.get('numeroCuenta')?.disable({ onlySelf: true });
    
    this.placeholderDinero = 'Valor Consignar';
    
  }
  
  ConsultarSaldo(tarjeta: any){
    this.tipoOperacion = 2;
    this.accion = 'Consultar Saldo';
    this.id = tarjeta.id;
    this.form.patchValue({
      fistName: tarjeta.fistName,
      lastName: tarjeta.lastName,
      brithDate: tarjeta.brithDate,
      numeroCuenta: tarjeta.numeroCuenta,
      dinero: "",
      password: "",
    });
    this.placeholderDinero = 'Dinero';
    this.form.get('fistName')?.disable({ onlySelf: true });
    this.form.get('lastName')?.disable({ onlySelf: true });
    this.form.get('brithDate')?.disable({ onlySelf: true });
    this.form.get('dinero')?.disable({ onlySelf: true });
    this.form.get('numeroCuenta')?.disable({ onlySelf: true });
    
  }
  
}
