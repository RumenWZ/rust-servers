import { Component } from '@angular/core';
import { ServerService } from '../services/server.service';

@Component({
  selector: 'app-server-list',
  templateUrl: './server-list.component.html',
  styleUrls: ['./server-list.component.css']
})
export class ServerListComponent {
  servers: any[] = [];

  constructor(
    private serverService: ServerService
  ) {

  }

  getTeamSize(teamsize: number) {
    var result;

    switch(teamsize) {
      case 1:
        result = 'Solo';
        break;
      case 2:
        result = 'Duo';
        break;
      case 3:
        result = 'Trio';
        break;
      default:
        result = 'Error';
        break;
    }
    return result;
  }

  ngOnInit() {
    this.serverService.getServers().subscribe((response: any) => {
      this.servers = response;
      console.log(this.servers);
    })
  }

}
