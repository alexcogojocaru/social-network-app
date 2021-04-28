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
  data = {
    username: 'alex'
  }

  constructor(private http: HttpClient) { 
    this.form = new FormGroup({
      username: new FormControl(),
      firstName: new FormControl(),
      lastName: new FormControl(),
      email: new FormControl(),
      phone: new FormControl(),
      password: new FormControl(),
    });
  }

  ngOnInit() {
  }

  postData(data) {
    var url = 'http://localhost:5001/api/user';

    this.http.post(url, data).subscribe((result) => {
      console.warn(result);
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
