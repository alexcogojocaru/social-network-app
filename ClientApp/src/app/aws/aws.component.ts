import { Component, OnInit } from '@angular/core';
import * as S3 from 'aws-sdk/clients/s3';

// class S3Controller {
//   FOLDER = 'images';
//   BUCKET = 'social-network-app-ip';

//   private static getS3Bucket(): any {
//     return new S3(
//       {
//         accessKeyId: 'AKIA2EZ3GLQX75IGRTW7',
//         secretAccessKey: 'FGZJ9Qpg1lnpp1IhXmPXx',
//         region: 'eu-central-1'
//       }
//     );
//   }

//   ngOnInit() {
    
//   }
// }

@Component({
  selector: 'app-aws',
  templateUrl: './aws.component.html',
  styleUrls: ['./aws.component.css']
})
export class AwsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
