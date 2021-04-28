import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  url: string;
  users: User[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.form = new FormGroup({
      username: new FormControl(),
      password: new FormControl()
    });

    this.url = baseUrl + '/api/user';
  }

  ngOnInit() {
  }

  onSubmit() {
    var user = {
      "username": this.form.get('username').value,
      "password": this.form.get('password').value
    };

    this.fetchUsers(user)
  }

  fetchUsers(user) {
    this.http.get<User[]>(this.url).subscribe(result => {
      this.users = result;

      this.users.forEach(it => {
        if ((it.username == user["username"]) && (it.password == user["password"])) {
          
        }
      });
    }, error => console.error(error));
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
