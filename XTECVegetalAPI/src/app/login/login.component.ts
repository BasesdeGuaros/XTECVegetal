import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    public listUsuario = [];
    model: any = {};
    public account = "";


  constructor(
      private router: Router,

  ) { }

  ngOnInit(): void {
  }

  
  validation(){
  }
  functionDeportista(){
      this.account = "1";
  }

  functionAdministrador(){
      this.account = "2";
  }
  


}

