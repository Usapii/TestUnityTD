# Projet Unity 
## Université orleans - Licence professionnelle

## __Sujet__

Le principe est le même que le TP du vaisseau spatiale: *Avancer au travers des astéroids*.

Le joueur a la possibilité de tirer avec un __délai__ de 0.5 secondes entre chaque tirs. Quand un tir rencontre un astéroid, ils sont tous deux détruit.

À l'écran, __deux barres__ seront visible: La barre de __vie__ du joueur, et la barre de __progression__ du niveau en cours.
- La barre de vie du joueur se videra au fur et a mesure que le vaisseai rencontrera des __obstacles__. Si la barre de vie arrive à 0. __L'animation de mort__ se déclenchera, et le jeux retournera a __l'écran titre__.

- La barre de progression représente __l'avancement dans le niveau__ en cours. Arrivé à la fin du premier niveau, le deuxième se lancera automatiquement. A la fin du deuxième niveau, le __boss__ apparaitra sur le coté de l'écran, et les astéroids disparaitront. Les __missiles__ du joueurs occasionneront des dégats, tandis que le boss essayera de __blesser le joueur__ en lui lançant __cometes__, et __lasers__.

___
### __Problèmes Rencontrées__
Le premier problème n'est pas un problème technique mais __d'organisation__.
Beaucoup de choses étaient prévues en commençant le projet, mais peu ont été gardés par manque de temps _(Les idées seront détaillées dans la dernière partie)_.

Les fichiers _(notamment les Images)_ de base fournit lors du TP n'etait pas adapté à une utilisation optimisé. J'ai du créer une __planche de sprite__ avec les images que vous nous aviez fournit. Certaines __images annexes__ au TP ont également été rajoutées dans la planche de sprite. 

__Deux autres planches__ ont été rajoutées par rapport au sprites du TP. Une planche trouvé sur le net, représentant les frame d'une __explosion__. Une autre fait main a partir d'un __fanart__ trouver sur le net. Cette dernière est partit d'une seul sprite, __dupliqué et modifier__, pour créer les __animations du boss__ de fin.

Beaucoup __d'effet visuel__ du jeu se base sur __l'enchainement des animations__. Il à fallu jongler entre animation des "__objets__" _(déplacement spécifique/conditionelle)_, et des __sprites__. Des scripts précis ont été créer pour certaines animations, et ce sont les autres scripts généraux qui __ajoutent__ ou __supprime__ ces mouvements. Certains mouvement sont prévue pour __se désactiver automatquement__ après un certains temps.

___
### __Appareils Disponible__
Tous les tests se sont fait sur la version WebGL.
À cause, d'un problème de paramétrage et d'organisation, les test sur la version Android n'ont pâs pû etre fait.
___

### __Informations Complémentaires__
 _None_
___
### __Améliorations prévues__
> Sound Manager

Un oubli complet de ma part, je n'ai pensé à __ajouter du son__ qu'au dernier moment, alors que les parties fonctionnelles _(Enchainement des niveaux, comportement du boss, etc ..)_ n'etait toujours pas implémentés. 

> Scénarisation

Il avait été prévue de __scénariser le jeu__, et d'y intégrer des __dialogues__ entre de potentielles __personnages__. Cela aurait entrainé de _penser_ le __scénario__, ainsi que tous les scripts de déplacement/ cinematiques, et de dialogues des personnages. 

> Personnalisation

Il avait été prévue de personnaliser plus le jeux.
Afficher un champ au début du jeu ou __le joueur rentrerai son surnom__.
Il aurait été __réutilisé__ par la suite __dans les dialogues__ entre les personnages.

> Bonus

Le __sprite des bonus__ est présent dans la planche de Sprite. Le bonus devait etre généré avec un nombre __aléatoire__ qui __choisirait son effet et sa couleur__. Les effets prévues etaient:
 - Augmenter la vitesse de tir.
 - Augmenter la taille des tirs.
 - Augmenter la resistance des tirs _(Détruire 2 astéroids avant de disparaitre)_.
 - Augmenter/ Diminuer la taille du vaisseau.
 - Augmenter/ Diminuer le nombre d'astéroids à l'écran.
 - Changer le type de tir _(Triple, Laser continue, mines, ...)_

Ces bonus auraient été __gardés à travers les niveauxc.

> Difficulté

Le boss de fin devait etre __plus dur__. Plus de __pattern d'attaques__ etait prévue.
Il devait également y avoir __un autre boss__ placé derrière le joueur, qui aurait induit d'autre __mécaniques__ _(i.e: Tirer sur des astéroids précis pour blesser le boss)_

D'autre __ennemis__ aurait dù etre rajouté dans le premier niveau, qui aurait __attaquer directement__ le joueur plutot que rentrer en collision avec lui. 
___

___
Si j'y arrive, le jeu devrait etre disponible à l'adresse : http://falguieres.xyz/nicolas/shiprojy
