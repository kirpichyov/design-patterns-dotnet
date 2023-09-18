using DesignPatterns.Memento;

var gameMenu = new GameMenu();

var game = new Game();
game.Show();

var save1 = game.Save();
gameMenu.StoreSave(save1, "sav1");

game.Play();
game.Show();

var save2 = game.Save();
gameMenu.StoreSave(save2, "sav2");

var loadedSave1 = gameMenu.LoadSave("sav1");
game.Restore(loadedSave1);
game.Show();

var loadedSave2 = gameMenu.LoadSave("sav2");
game.Restore(loadedSave2);
game.Show();