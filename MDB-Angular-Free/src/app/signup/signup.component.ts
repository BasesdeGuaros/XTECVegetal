import { Component, OnInit } from '@angular/core';
import { reply } from '../Models/reply'



@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
    public listUsuarios = [];


  constructor(
  ) { }

  optionsSelect: Array<any>;
  ngOnInit() {


    this.optionsSelect = [
      { value: 'Feedback', label: 'Feedback' },
      { value: 'Report a bug', label: 'Report a bug' },
      { value: 'Feature request', label: 'Feature request' },
      { value: 'Other stuff', label: 'Other stuff' },
    ];
  }
  model: any = {};

   function() {
       console.log("Hola");
      
  }
}
