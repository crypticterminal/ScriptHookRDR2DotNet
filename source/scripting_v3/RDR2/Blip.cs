using RDR2.Math;
using RDR2.Native;
using System;

namespace RDR2
{
	public sealed class Blip : PoolObject, IEquatable<Blip>
	{
		public Blip( int handle ) : base( handle ) {

		}

		public BlipSprite Sprite
		{
			set => Function.Call( Hash.SET_BLIP_SPRITE, Handle, (uint)value );
		}
		
		public void ModifierAdd(BlipModifier modifier)
		{
			 Function.Call(Hash._0x662D364ABF16DE2F, Handle, (uint)modifier);
		}
		
		public void ModifierRemove(BlipModifier modifier)
		{
			Function.Call(Hash._SET_BLIP_FLASH_STYLE, Handle, (uint)modifier);
		}
		
		public Vector2 Scale
		{
			set => Function.Call( Hash.SET_BLIP_SCALE, Handle, value.X, value.Y );
		}

		public string Label
		{
			set => Function.Call(Hash._SET_BLIP_NAME_FROM_PLAYER_STRING, Handle,
				Function.Call<string>(Hash._CREATE_VAR_STRING, 10, "LITERAL_STRING", value));
		}

		public bool IsFlashing
		{
			set => Function.Call( Hash.SET_BLIP_FLASHES, Handle, value, 2 );
		}

		public bool IsOnMinimap => Function.Call<bool>( Hash.IS_BLIP_ON_MINIMAP, Handle );

		public override bool Exists() {
			return Function.Call<bool>( Hash.DOES_BLIP_EXIST, Handle );
		}

		public override void Delete() {
			Function.Call( Hash.REMOVE_BLIP, Handle );
		}

		public bool Equals( Blip other ) {
			return !ReferenceEquals( null, other ) && other.Handle == Handle;
		}

		public override bool Equals( object obj ) {
			return ReferenceEquals( this, obj ) || obj is Blip other && Equals( other );
		}

		public override int GetHashCode() {
			return Handle.GetHashCode();
		}
	}

	/// <summary>
	/// The sprite icon to set the blip to. Here's a
	/// <see href="https://cdn.discordapp.com/attachments/450373719974477835/643937562091716638/unknown.png">reference image</see>
	/// in order from left-to-right by GlitchDetector, and each row indicates the different type.
	/// </summary>
	public enum BlipSprite : uint
	{
		Dominoes = 0x9D9FE583,
		DominoesAllFives = 0xFD189BDE,
		DominosAllThrees = 0xA1C2EBE4,
		FiveFingerFillet = 0x75B54B90,
		FiveFingerFilletGuts = 0x7869CF4,
		FiveFingerFilletBurnout = 0x3C88E424,
		Poker = 0x4A2357A9,
		SaddleBag = 0xB0E5E617,
		Doctor = 0x984E7CA9,
		EatingUtensils = 0x37BEBE4E,
		DonateToCamp = 0x8B7E38C4,
		ObjectiveChore = 0xDDFBA6AB,
		Ammunition = 0x5DF6DEBD,
		HealthSupplies = 0xD68D851B,
		Provisions = 0x919BC110,
		SmallBlackDot = 0x4ECB0761,
		Wheel = 0x3C5469D5,
		Stranger = 0x935EE440,
		Drinking = 0x4A0E7F51,
		HuntingGrounds = 0x1DCFAA8C,
		Fishing = 0xA216510E,
		MoneyWheel = 0xD4859AFE,
		Bank = 0x25249A47,
		Herd = 0x193BD50E,
		CaravanCamp = 0xA0417C98,
		HomeRobbery = 0x1A7A040D
	}
	public enum BlipModifier : uint
	{
		BLIP_MODIFIER_AREA = 0xA2814CC7,
		BLIP_MODIFIER_AREA_CLAMPED_PULSE = 0xA0A765A1,
		BLIP_MODIFIER_AREA_CONTESTED = 0x6E1AE519,
		BLIP_MODIFIER_AREA_DIRECTIONAL = 0x38E24039,
		BLIP_MODIFIER_AREA_HIDE_ON_INSIDE = 0xAD9CBA59,
		BLIP_MODIFIER_AREA_HIDE_ON_OUTSIDE = 0xD4BC0DD7,
		BLIP_MODIFIER_AREA_OUT_OF_BOUNDS = 0xAB81D4D6,
		BLIP_MODIFIER_AREA_PULSE = 0x1BE311B3,
		BLIP_MODIFIER_AREA_TAKEOVER = 0x3494D1C8,
		BLIP_MODIFIER_ATTENTION = 0x240DE18,
		BLIP_MODIFIER_BOUNTY_TARGET_INCAPACITATED = 0xF51B7DD8,
		BLIP_MODIFIER_COMPANION_ACTIVITY = 0x56B8B889,
		BLIP_MODIFIER_COMPANION_CONVERSATION = 0xB4CA5F4C,
		BLIP_MODIFIER_COMPANION_DOG = 0xB93E613,
		BLIP_MODIFIER_COMPANION_OBJECTIVE = 0xDF69E371,
		BLIP_MODIFIER_COMPANION_WOUNDED = 0x18006B2F,
		BLIP_MODIFIER_COMPASS_OBJECTIVE = 0xDC7BE1A,
		BLIP_MODIFIER_CREATOR_FOCUS = 0x557F109C,
		BLIP_MODIFIER_CULL_ON_DEATH = 0xAA235D8B,
		BLIP_MODIFIER_DIRECTION_ONLY = 0x5824DF7B,
		BLIP_MODIFIER_DISTANCE_FADE_LONG = 0x8F934A09,
		BLIP_MODIFIER_DISTANCE_FADE_MEDIUM = 0x23BCF4A2,
		BLIP_MODIFIER_DISTANCE_FADE_SHORT = 0x111DDB96,
		BLIP_MODIFIER_ENEMY = 0x382616F3,
		BLIP_MODIFIER_ENEMY_AQUATIC = 0x4BCEFC2C,
		BLIP_MODIFIER_ENEMY_CONFRONTING = 0x2CB39D87,
		BLIP_MODIFIER_ENEMY_DISAPPEARING = 0x7CFAB4C0,
		BLIP_MODIFIER_ENEMY_DISAPPEARING_NO_FLEE_CHECKS = 0xFCDCDBA,
		BLIP_MODIFIER_ENEMY_DISAPPEARING_NO_SCREEN_CHECKS = 0x1852773,
		BLIP_MODIFIER_ENEMY_FLEEING = 0x1FDAEC84,
		BLIP_MODIFIER_ENEMY_GUNSHOTS_FADE_ON_START = 0x57F061DF,
		BLIP_MODIFIER_ENEMY_GUNSHOTS_ONLY = 0xC256FEAF,
		BLIP_MODIFIER_ENEMY_GUNSHOTS_ONLY_DONT_SHOW_LAST = 0x27CCDA52,
		BLIP_MODIFIER_ENEMY_IS_ALERTED = 0xF85DCD5A,
		BLIP_MODIFIER_ENEMY_LOWER_AWARENESS = 0x50235612,
		BLIP_MODIFIER_ENEMY_MUST_AGGRO = 0x69392A93,
		BLIP_MODIFIER_ENEMY_ON_GUARD = 0xD886D9BD,
		BLIP_MODIFIER_ENEMY_ON_GUARD_DISAPPEARING = 0x5C6421C6,
		BLIP_MODIFIER_ENEMY_STEALTH_KILL = 0xBD592C8A,
		BLIP_MODIFIER_ENEMY_TARGETED_ONLY = 0xE9CA636F,
		BLIP_MODIFIER_FADE = 0xBC9C3EA,
		BLIP_MODIFIER_FADE_OUT_AND_DIE = 0xB452F7BC,
		BLIP_MODIFIER_FADE_OUT_SLOW = 0x5426DAB6,
		BLIP_MODIFIER_FETCH_ESCAPING = 0xE6239722,
		BLIP_MODIFIER_FLASH_FOREVER = 0xC1DBF36F,
		BLIP_MODIFIER_FOR_SALE = 0xDAA61911,
		BLIP_MODIFIER_FORCE_GPS = 0x900A4D0A,
		BLIP_MODIFIER_FRIENDLY = 0x6414AA9A,
		BLIP_MODIFIER_FRIENDLY_OBJECTIVE = 0xC586CF7A,
		BLIP_MODIFIER_HIDDEN = 0xB946AEF0,
		BLIP_MODIFIER_HIDEOUT_ABANDONED = 0x9916A554,
		BLIP_MODIFIER_HIGH_CATEGORY = 0xCCC27837,
		BLIP_MODIFIER_JOB = 0x845A1E41,
		BLIP_MODIFIER_JOB_BILL = 0x5A9CF68D,
		BLIP_MODIFIER_JOB_CHARLES = 0x382968CB,
		BLIP_MODIFIER_JOB_HOSEA = 0x24D547E,
		BLIP_MODIFIER_JOB_JAVIER = 0xA66B982F,
		BLIP_MODIFIER_JOB_JOHN = 0x7EA2F90A,
		BLIP_MODIFIER_JOB_KAREN = 0x955011CB,
		BLIP_MODIFIER_JOB_KIERAN = 0x78BE3FBC,
		BLIP_MODIFIER_JOB_LENNY = 0x81F28880,
		BLIP_MODIFIER_JOB_LOANSHARK = 0x1D8CAE74,
		BLIP_MODIFIER_JOB_MICAH = 0xA26E278F,
		BLIP_MODIFIER_JOB_PEARSON = 0xC5B01DDB,
		BLIP_MODIFIER_JOB_SEAN = 0x31FDE57D,
		BLIP_MODIFIER_JOB_STRAUSS = 0x4FEF10D0,
		BLIP_MODIFIER_JOB_TILLY = 0xCAA7A516,
		BLIP_MODIFIER_JOB_UNCLE = 0xAAD9F18,
		BLIP_MODIFIER_KEY_JOB = 0x27045619,
		BLIP_MODIFIER_LAW_ORDER = 0x96AEC03E,
		BLIP_MODIFIER_LOCAL_PLAYER_OWNED = 0xB3892473,
		BLIP_MODIFIER_LOCKED = 0x2B30E11F,
		BLIP_MODIFIER_LOS_DISAPPEARING = 0x1C65CE16,
		BLIP_MODIFIER_MISSION_UNAVAILABLE = 0x821511C0,
		BLIP_MODIFIER_MP_COLOR_1 = 0x1DD3A06B,
		BLIP_MODIFIER_MP_COLOR_10 = 0x6A44C8F2,
		BLIP_MODIFIER_MP_COLOR_11 = 0xA6964198,
		BLIP_MODIFIER_MP_COLOR_12 = 0x57E2242D,
		BLIP_MODIFIER_MP_COLOR_13 = 0x8A3D88E7,
		BLIP_MODIFIER_MP_COLOR_14 = 0xB77BE363,
		BLIP_MODIFIER_MP_COLOR_15 = 0xEF61D32E,
		BLIP_MODIFIER_MP_COLOR_16 = 0xA1A7B7BB,
		BLIP_MODIFIER_MP_COLOR_17 = 0xD2CF1A09,
		BLIP_MODIFIER_MP_COLOR_18 = 0x518FE9C,
		BLIP_MODIFIER_MP_COLOR_19 = 0x38AB65C4,
		BLIP_MODIFIER_MP_COLOR_2 = 0x6F85C3CE,
		BLIP_MODIFIER_MP_COLOR_20 = 0x121C9983,
		BLIP_MODIFIER_MP_COLOR_21 = 0x7D55EFF4,
		BLIP_MODIFIER_MP_COLOR_22 = 0x6700C34A,
		BLIP_MODIFIER_MP_COLOR_23 = 0x8EA29299,
		BLIP_MODIFIER_MP_COLOR_24 = 0xA3F7BD43,
		BLIP_MODIFIER_MP_COLOR_25 = 0xF351DBF6,
		BLIP_MODIFIER_MP_COLOR_26 = 0xF85BE60A,
		BLIP_MODIFIER_MP_COLOR_27 = 0xCCED8F2E,
		BLIP_MODIFIER_MP_COLOR_28 = 0xDB4D2BED,
		BLIP_MODIFIER_MP_COLOR_29 = 0x29894868,
		BLIP_MODIFIER_MP_COLOR_3 = 0x8D2FFF22,
		BLIP_MODIFIER_MP_COLOR_30 = 0xE643BEC2,
		BLIP_MODIFIER_MP_COLOR_31 = 0xFEDE6FF7,
		BLIP_MODIFIER_MP_COLOR_32 = 0xEF1F5079,
		BLIP_MODIFIER_MP_COLOR_4 = 0xECA93E13,
		BLIP_MODIFIER_MP_COLOR_5 = 0x3A585978,
		BLIP_MODIFIER_MP_COLOR_6 = 0x481674F4,
		BLIP_MODIFIER_MP_COLOR_7 = 0x15BD9043,
		BLIP_MODIFIER_MP_COLOR_8 = 0xA1B5A82D,
		BLIP_MODIFIER_MP_COLOR_9 = 0xF376CBAE,
		BLIP_MODIFIER_MP_DOWNED = 0x24CB3FB5,
		BLIP_MODIFIER_MP_ENEMY_HOLDING = 0x738B1D05,
		BLIP_MODIFIER_MP_FRIENDLY_HOLDING = 0x22E21DB2,
		BLIP_MODIFIER_MP_HOT_BLIP = 0x2B389337,
		BLIP_MODIFIER_MP_HUNTER = 0x56AA576C,
		BLIP_MODIFIER_MP_JOB_PLAYER_FADE = 0xB87AC128,
		BLIP_MODIFIER_MP_NEUTRAL = 0x7C687658,
		BLIP_MODIFIER_MP_OBJECTIVE = 0xE0E7C82B,
		BLIP_MODIFIER_MP_OBJECTIVE_ENEMY = 0x801DD820,
		BLIP_MODIFIER_MP_OBJECTIVE_FRIENDLY = 0xA9DBBFDC,
		BLIP_MODIFIER_MP_OBJECTIVE_NEUTRAL = 0x9E703B63,
		BLIP_MODIFIER_MP_PLAYER_ALLY = 0xB1AE1182,
		BLIP_MODIFIER_MP_PLAYER_ALLY_WOUNDED = 0xDAC99B52,
		BLIP_MODIFIER_MP_PLAYER_CONTROL = 0x3A6AF541,
		BLIP_MODIFIER_MP_PLAYER_COOP = 0xA4F9F040,
		BLIP_MODIFIER_MP_PLAYER_DISAPPEARING = 0x40FB8A3E,
		BLIP_MODIFIER_MP_PLAYER_ENEMY = 0xDB76C121,
		BLIP_MODIFIER_MP_PLAYER_LOS_ONLY = 0xFDB13448,
		BLIP_MODIFIER_MP_PLAYER_NEUTRAL = 0x5F947624,
		BLIP_MODIFIER_MP_PLAYER_WINNING = 0xE0F654CC,
		BLIP_MODIFIER_MP_PLAYER_WITH_BOUNTY = 0x2B28A10C,
		BLIP_MODIFIER_MP_REVIVE = 0x9125D4D4,
		BLIP_MODIFIER_MP_RIVAL_RACER = 0x3599864F,
		BLIP_MODIFIER_MP_TEAM_COLOR_1 = 0x9B795DF5,
		BLIP_MODIFIER_MP_TEAM_COLOR_2 = 0x4F530F3,
		BLIP_MODIFIER_MP_TEAM_COLOR_3 = 0x232C6D61,
		BLIP_MODIFIER_MP_TEAM_COLOR_4 = 0x6876F7FD,
		BLIP_MODIFIER_MP_TEAM_COLOR_5 = 0xF6B79478,
		BLIP_MODIFIER_MP_TEAM_COLOR_6 = 0xDBC05E8A,
		BLIP_MODIFIER_MP_TEAM_COLOR_7 = 0xEA06FB17,
		BLIP_MODIFIER_MP_TEAM_COLOR_8 = 0xAFF286EF,
		BLIP_MODIFIER_MP_WHITE_FLAG = 0x35333C20,
		BLIP_MODIFIER_NEUTRAL_ON_GUARD = 0x4FCB6ECC,
		BLIP_MODIFIER_OBJECTIVE = 0xE80A86F4,
		BLIP_MODIFIER_OUTSIDE_TOD = 0xA9C5EBA4,
		BLIP_MODIFIER_OVERLAY_1 = 0xE7DF610D,
		BLIP_MODIFIER_OVERLAY_2 = 0xFD868C57,
		BLIP_MODIFIER_OVERLAY_3 = 0xBD028EA,
		BLIP_MODIFIER_OVERLAY_4 = 0xA30F576E,
		BLIP_MODIFIER_OVERLAY_5 = 0xB151F3F3,
		BLIP_MODIFIER_OVERLAY_RING_MP_COLOR_1 = 0xD9349943,
		BLIP_MODIFIER_OVERLAY_RING_MP_COLOR_10 = 0x9EB41558,
		BLIP_MODIFIER_OVERLAY_RING_MP_COLOR_2 = 0x71284930,
		BLIP_MODIFIER_OVERLAY_RING_MP_COLOR_3 = 0x5FBB2656,
		BLIP_MODIFIER_OVERLAY_RING_MP_COLOR_4 = 0x2662339D,
		BLIP_MODIFIER_OVERLAY_RING_MP_COLOR_5 = 0x8434EF49,
		BLIP_MODIFIER_OVERLAY_RING_MP_COLOR_6 = 0x4FA0861D,
		BLIP_MODIFIER_OVERLAY_RING_MP_COLOR_7 = 0xBE67E3AA,
		BLIP_MODIFIER_OVERLAY_RING_MP_COLOR_8 = 0x74354F46,
		BLIP_MODIFIER_OVERLAY_RING_MP_COLOR_9 = 0x60E428A4,
		BLIP_MODIFIER_OVERLAY_WHITE_1 = 0x508D5857,
		BLIP_MODIFIER_OVERLAY_WHITE_2 = 0x7B482DD0,
		BLIP_MODIFIER_OVERLAY_WHITE_3 = 0xDD10F160,
		BLIP_MODIFIER_OVERLAY_WHITE_4 = 0x99B56AAA,
		BLIP_MODIFIER_OVERLAY_WHITE_5 = 0x8BC4CEC9,
		BLIP_MODIFIER_PARTY = 0xD80C073B,
		BLIP_MODIFIER_PICKUP_NEW = 0x2818329D,
		BLIP_MODIFIER_POSSE_ALLY = 0xAD76DF0A,
		BLIP_MODIFIER_POSSE_ALLY_OWNED = 0x1B05ACFB,
		BLIP_MODIFIER_POSSE_ENEMY = 0xD2FC82A6,
		BLIP_MODIFIER_POSSE_ENEMY_OWNED = 0x5E944732,
		BLIP_MODIFIER_POSSE_NEUTRAL = 0x1DF90851,
		BLIP_MODIFIER_POSSE_NEUTRAL_OWNED = 0x617D58CD,
		BLIP_MODIFIER_PULSE_FOREVER = 0xD34253F0,
		BLIP_MODIFIER_RADAR_EDGE_ALWAYS = 0x32850803,
		BLIP_MODIFIER_RADAR_EDGE_NEVER = 0xF366785F,
		BLIP_MODIFIER_SCALE_1 = 0x1DC9C9D4,
		BLIP_MODIFIER_SCALE_2 = 0x2ECDEBDC,
		BLIP_MODIFIER_SHOP_UNAVAILABLE = 0x470BBD53,
		BLIP_MODIFIER_SHOW_HEIGHT = 0x3E605A6D,
		BLIP_MODIFIER_SHRINK_WARNING_1 = 0x2A8907B4,
		BLIP_MODIFIER_SHRINK_WARNING_2 = 0x384BA339,
		BLIP_MODIFIER_TEXT_ONLY = 0xF168692F,
		BLIP_MODIFIER_TOD_DAYTIME_ONLY = 0x2E9B7ACE,
		BLIP_MODIFIER_TOD_NIGHTTIME_ONLY = 0x717A8A2E,
		BLIP_MODIFIER_TOWN_POSSE_MEMBER = 0x40BEFB22,
		BLIP_MODIFIER_TRACKING = 0x287E1591,
		BLIP_MODIFIER_TRAIN_MISSION = 0xE1DE479D,
		BLIP_MODIFIER_UNDISCOVERED = 0x794450C7,
		BLIP_MODIFIER_URGENT = 0xFD364272,
		BLIP_MODIFIER_URGENT_ALERT = 0x229A6F60,
		BLIP_MODIFIER_VERYHIGH_CATEGORY = 0x6A55DFDE,
		BLIP_MODIFIER_WANTED_PULSE_1 = 0x76674069,
		BLIP_MODIFIER_WANTED_PULSE_2 = 0x8CC46D23,
		BLIP_MODIFIER_WANTED_PULSE_3 = 0x1EC09125,
		BLIP_MODIFIER_WANTED_PULSE_4 = 0x3483BCAB,
		BLIP_MODIFIER_WANTED_PULSE_5 = 0x266D86E,
		BLIP_MODIFIER_WITNESS_IDENTIFIED = 0x190F3B7C,
		BLIP_MODIFIER_WITNESS_INVESTIGATING = 0x5E176D3A,
		BLIP_MODIFIER_WITNESS_UNIDENTIFIED = 0xFAA28257,
	}
	public enum BlipType : uint
	{
		CompanionGray = 0x19365607,
		PickupWhite = 0xEC972124,
		WeaponWhite = 0x63351D54,
		WhiteDot = 0xB04092F8,
		Flashing = 0x4B1C3939,
		EnemyPink = 0x9A7FB0BF,
		DestinationSmall = 0xC19DA63,
		DestinationGray = 0xD792CF71,
		PosseCamp = 0x5D0509CC,
		DestinationLarge = 0x1857A152,
		DestinationDark = 0x64994D7C
	}}
