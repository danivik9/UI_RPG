SPĒLES APRAKSTS

Spēlei izvēlējos "Western" tematiku. Fona attēlu paņēmu no pinterest, Teksta fontu no Google Fonts, Pogu sprites un pretinieka "idle" un "shooting" sprites izveidoju pati Illustratora.
Spēle tu "Bob" cīnies pret tavā teritorijā ierukušo "Boo", izmantojot dažādus ieročus kā "revolver", "shotgun" un "rifle". Katru reizi kad pretinieks tiek uzvarēts, spēle kļūst grūtāka.

PAPILDUZDEVUMI

3 IEROČU TIPI

Revolver - pamata ierocis ar vienkāršu damage no min līdz max.
Shotgun - šauj vairākas lodes (pellets) vienlaicīgi. Katra lode dara savu damage, tāpēc kopējais damage var būt gan liels, gan mazs. Tas strādā ar for ciklu kas iziet cauri katrai lodei.
Rifle - precīzs ierocis ar iespēju trāpīt galvā (critical hit). Ir 30% iespēja ka damage tiks dubultots. Izmantoju vienkāršu if pārbaudi ar Random.Range.

LĪMEŅU SISTĒMA

Kad pretinieka HP sasniedz 0, spēlētājs pāriet nākamajā līmenī. 
Ar katru līmeni pretinieks kļūst stiprāks - viņa min un max damage palielinās. 
Tāpēc ar katru līmeni ir lielāka iespēja zaudēt.

HEAL

Spēlētājam ir iespēja dziedināt sevi vienu reizi katrā līmenī. Kad nospiež Heal pogu, spēlētājs atgūst 15 HP. Pēc līmeņa paaugstināšanas heal atkal kļūst pieejams.

SKAŅAS EFEKTI

Katram ierocim ir savs skaņas efekts. Kad spēlētājs uzbrūk, atskaņojas aktīvā ieroča skaņa. Skaņas klips tiek pievienots caur Inspector katram ierocim atsevišķi.

PRETINIEKA SPRITE MAIŅA

Pretiniekam ir divi attēli IDLE un SHOOTING. Kad pretinieks uzbrūk, attēls mainās uz šaušanas sprite uz 0.5 sekundēm un tad atgriežas atpakaļ.

GAME OVER

Kad spēlētāja HP sasniedz 0, parādās Game Over panelis ar Restart pogu. Nospiežot Restart, spēle sākas no jauna.

HP AIZIET LĪDZ 0

Pievienoju pārbaudi ka HP nevar nokrist zem 0. Ja damage ir lielāks nekā atlikušais HP, tas vienkārši paliek uz 0.

OOP

1. Mantošana
Tika izveidota Character, no kuras manto gan Player, gan Enemy. Abām klasēm ir kopīgas lietas - health, vārds, TakeDamage metode. 
Ieročiem ir bāzes klase Weapon, no kuras manto ShotgunWeapon un RifleWeapon. Katrs ierocis pārmanto pamata damage sistēmu un pievieno savu loģiku.

3. Enkapsulācija
Izmantoju private mainīgos ar getter un setter struktūrām. 
CharName ir private un tam ir tikai getter - to var nolasīt bet nevar mainīt no ārienes. 
CanHeal ir private bool ar getter, lai citas klases var pārbaudīt vai heal ir pieejams, bet nevar to mainīt tieši.

5. Polimorfisms 
Override: katra ieroča klase override metodi GetDamage().
Revolver izmanto pamata versiju, Shotgun pievieno pellet sistēmu, Rifle pievieno critical hit.
Player un Enemy override Attack() metodi no Character klases - katrs uzbrūk savādāk.
Overload: Character klasē ir divas TakeDamage metodes. Viena pieņem float skaitli, otra pieņem Weapon objektu. Abas dara līdzīgu lietu bet ar dažādiem parametriem.

4. Abstrakcija
Character klase ir abstrakta: no tās nevar izveidot objektu tieši. Tai ir abstrakta metode Attack() kuru katrai child klasei (Player un Enemy) ir jāpārraksta pašai.
Weapon klase kalpo kā bāzes klase ieročiem ar virtuālu GetDamage() metodi ko child klases var pārrakstīt.

