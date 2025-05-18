import { SynonmDto } from "./synonmDto";

export interface AddWordCommandRequest {
    ForeignWord: string;
    TranslatedWord: string;
    Synonms: SynonmDto[];
}
