import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { WordService } from '../../services/word.service';
import { AddWordCommandRequest } from '../../models/commands/add/addWordCommandRequest';
import { SynonmDto } from '../../models/commands/add/synonmDto';

@Component({
  selector: 'app-create-word',
  imports: [ReactiveFormsModule,NgFor],
  templateUrl: './create-word.component.html',
  styleUrl: './create-word.component.css'
})
export class CreateWordComponent {
wordForm: FormGroup;

  constructor(private fb: FormBuilder,private wordService: WordService) {
    this.wordForm = this.fb.group({
      word: ['', Validators.required],
      translate: ['', Validators.required],
      synonyms: this.fb.array([
        this.createSynonymGroup()  // Başlangıç için bir tane synonym
      ])
    });
  }

  createSynonymGroup(): FormGroup {
    return this.fb.group({
      word: ['', Validators.required],
      translate: ['', Validators.required]
    });
  }

  // synonyms FormArray getter
  get synonymControls() {
    return this.wordForm.get('synonyms') as FormArray;
  }

  // Yeni synonym ekle
  addSynonym() {
    this.synonymControls.push(this.createSynonymGroup());
  }

  // Submit
  onSubmit() {
    if (this.wordForm.valid) {
      console.log('Form Data:', this.wordForm.value);
      const request:AddWordCommandRequest = {
        ForeignWord: this.wordForm.value.word,
        TranslatedWord: this.wordForm.value.translate,
        Synonms: this.wordForm.value.synonyms.map((synonym: any) => ({
          ForeignWord: synonym.word,
          TranslatedWord: synonym.translate
        }))
      };

      this.wordService.Add(request).subscribe(
        response => {
          this.wordForm.reset();
          this.synonymControls.clear(); 
          this.addSynonym(); 
        },
        error => {
          console.error('Error adding word:', error);
        }
      );
      
    } else {
      console.warn('Form invalid');
    }
  }
}
