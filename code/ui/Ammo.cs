﻿using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;


public class Ammo : Panel
{
	public Label Weapon;
	public Label Inventory;

	public Ammo()
	{
		Weapon = Add.Label( "", "weapon" );
		Inventory = Add.Label( "", "inventory" );
	}

	public override void Tick()
	{
		var player = Local.Pawn;
		if ( player == null ) return;

		var weapon = player.ActiveChild as WeaponBase;
		SetClass( "active", weapon != null );

		if ( weapon == null ) return;

		Weapon.Text = $"{weapon.AmmoClip}";

		var inv = weapon.AvailableAmmo();
		Inventory.Text = $" / {inv}";
		Inventory.SetClass( "active", inv >= 0 );
	}
}
