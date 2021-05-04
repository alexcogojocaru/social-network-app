import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { BurritoService } from '../burrito.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  url: string;

  constructor(
    private http: HttpClient, 
    private burritoService: BurritoService,
    @Inject('BASE_URL') baseUrl: string
    ) { 
    this.form = new FormGroup({
      username: new FormControl(),
      password: new FormControl()
    });

    this.url = baseUrl + 'api/user';
  }

  ngOnInit() {
  }

  onSubmit() {
    var user = {
      "username": this.form.get('username').value,
      "password": this.form.get('password').value
    };

    this.fetchUsers(user);
  }

  fetchUsers(user) {
    this.http.get<User[]>(this.url).subscribe(result => {
      if (result && !this.burritoService.getLoggedInfo()) {
        result.forEach(it => {
          console.log(`fetched user = ${it.username}`);

          if ((it.username === user["username"]) && (it.password === user["password"])) {
            this.burritoService.setLogInfo(true);
            
            localStorage.setItem(this.burritoService.getLoggedTag(), `${it.username}:${it.password}`);
          }
        });
      }
    }, error => console.error(error));

    console.log(this.burritoService.getLoggedInfo());
  }
}

interface User {
  username: string;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  password: string;
  sex: number;
  city: string;
  country: string;
}
