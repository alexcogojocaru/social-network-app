import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.form = new FormGroup({
      username: new FormControl(),
      firstName: new FormControl(),
      lastName: new FormControl(),
      email: new FormControl(),
      phone: new FormControl(),
      password: new FormControl(),
    });

    this.url = baseUrl + 'api/user';
  }

  ngOnInit() {
  }

  postData(data) {
    console.log(this.url);

    this.http.post(this.url, data).subscribe((result) => {
      console.log(result);
    });
  }

  onSubmit() {
    var user = {
      "username": this.form.get('username').value,
      "firstName": this.form.get('firstName').value,
      "lastName": this.form.get('lastName').value,
      "email": this.form.get('email').value,
      "phone": this.form.get('phone').value,
      "password": this.form.get('password').value,
      "sex": 1,
      "city": "Iasi",
      "country": "Romania"
    }

    this.postData(user)
  }
}
