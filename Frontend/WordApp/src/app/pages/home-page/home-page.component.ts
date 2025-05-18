import { Component, OnInit } from '@angular/core';
import { CreateWordComponent } from "../../components/create-word/create-word.component";
import { DailyWordComponent } from "../../components/daily-word/daily-word.component";
import { KnownWordComponent } from "../../components/known-word/known-word.component";
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-home-page',
  imports: [CreateWordComponent, DailyWordComponent, KnownWordComponent,NgIf],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent implements OnInit {
  selectedTab:number = 1;
  constructor() { }

  ngOnInit(): void {
  }

  public selectTab(tabIndex: number): void {
    this.selectedTab = tabIndex;
  }

}
