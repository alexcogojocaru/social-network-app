import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BurritoService } from '../burrito.service';
// import { User } from '../users/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  username: string;
  user: User;
  isLogged: boolean;
  friends: Friend[];
  url: string;
  
  constructor(
    private route: ActivatedRoute, 
    private http: HttpClient,
    private burritoService: BurritoService,
    @Inject('BASE_URL') baseUrl: string
    ) { 
    this.url = baseUrl;
    this.isLogged = this.burritoService.getLoggedInfo();
    this.username = this.route.snapshot.paramMap.get('username');
    
    console.log(`logged = ${this.isLogged}`);
    console.log(`name = ${this.username}`);

    http.get<User>(baseUrl + `api/user/${this.username}`).subscribe(result => {
      this.user = result;
    });

    http.get<Friend[]>(baseUrl + `api/friend/${this.username}`).subscribe(result => {
      this.friends = result;
    });
  }

  ngOnInit() {
    
  }

  unfriend(friendUsername) {
    console.log(friendUsername);
    this.http.delete(this.url + `api/friend/${this.username}?friendUsername=${friendUsername}`).subscribe(result => {
      console.log('Unfriended');
      window.location.reload();
    });
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

interface Friend {
  username: string;
  friendshipData: string;
}