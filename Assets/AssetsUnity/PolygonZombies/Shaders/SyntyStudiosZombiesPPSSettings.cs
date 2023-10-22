// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>
#if UNITY_POST_PROCESSING_STACK_V2
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess( typeof( SyntyStudiosZombiesPPSRenderer ), PostProcessEvent.AfterStack, "SyntyStudiosZombies", true )]
public sealed class SyntyStudiosZombiesPPSSettings : PostProcessEffectSettings
{
	[Tooltip( "Alpha Cutoff " )]
	public FloatParameter _AlphaCutoff = new FloatParameter { value = 0.5f };
	[Tooltip( "Emission Color" )]
	public ColorParameter _EmissionColor = new ColorParameter { value = new Color(1f,1f,1f,1f) };
	[Tooltip( "Texture" )]
	public TextureParameter _Texture = new TextureParameter {  };
	[Tooltip( "Blood" )]
	public TextureParameter _Blood = new TextureParameter {  };
	[Tooltip( "BloodColor" )]
	public ColorParameter _BloodColor = new ColorParameter { value = new Color(0.6470588f,0.2569203f,0.2569203f,0f) };
	[Tooltip( "BloodAmount" )]
	public FloatParameter _BloodAmount = new FloatParameter { value = 0f };
	[Tooltip( "Emissive" )]
	public TextureParameter _Emissive = new TextureParameter {  };
	[Tooltip( "Emissive Color" )]
	public ColorParameter _EmissiveColor = new ColorParameter { value = new Color(0f,0f,0f,0f) };
	[Tooltip( "" )]
	public TextureParameter _texcoord2 = new TextureParameter {  };
	[Tooltip( "Specular Highlights" )]
	public FloatParameter _SpecularHighlights = new FloatParameter { value = 1f };
	[Tooltip( "Environment Reflections" )]
	public FloatParameter _EnvironmentReflections = new FloatParameter { value = 1f };
	[Tooltip( "Receive Shadows" )]
	public FloatParameter _ReceiveShadows = new FloatParameter { value = 1f };
	[Tooltip( "_QueueOffset" )]
	public FloatParameter _QueueOffset = new FloatParameter { value = 0f };
	[Tooltip( "_QueueControl" )]
	public FloatParameter _QueueControl = new FloatParameter { value = -1f };
	[Tooltip( "unity_Lightmaps" )]
	public TextureParameter unity_Lightmaps = new TextureParameter {  };
	[Tooltip( "unity_LightmapsInd" )]
	public TextureParameter unity_LightmapsInd = new TextureParameter {  };
	[Tooltip( "unity_ShadowMasks" )]
	public TextureParameter unity_ShadowMasks = new TextureParameter {  };
}

public sealed class SyntyStudiosZombiesPPSRenderer : PostProcessEffectRenderer<SyntyStudiosZombiesPPSSettings>
{
	public override void Render( PostProcessRenderContext context )
	{
		var sheet = context.propertySheets.Get( Shader.Find( "SyntyStudios/Zombies" ) );
		sheet.properties.SetFloat( "_AlphaCutoff", settings._AlphaCutoff );
		sheet.properties.SetColor( "_EmissionColor", settings._EmissionColor );
		if(settings._Texture.value != null) sheet.properties.SetTexture( "_Texture", settings._Texture );
		if(settings._Blood.value != null) sheet.properties.SetTexture( "_Blood", settings._Blood );
		sheet.properties.SetColor( "_BloodColor", settings._BloodColor );
		sheet.properties.SetFloat( "_BloodAmount", settings._BloodAmount );
		if(settings._Emissive.value != null) sheet.properties.SetTexture( "_Emissive", settings._Emissive );
		sheet.properties.SetColor( "_EmissiveColor", settings._EmissiveColor );
		if(settings._texcoord2.value != null) sheet.properties.SetTexture( "_texcoord2", settings._texcoord2 );
		sheet.properties.SetFloat( "_SpecularHighlights", settings._SpecularHighlights );
		sheet.properties.SetFloat( "_EnvironmentReflections", settings._EnvironmentReflections );
		sheet.properties.SetFloat( "_ReceiveShadows", settings._ReceiveShadows );
		sheet.properties.SetFloat( "_QueueOffset", settings._QueueOffset );
		sheet.properties.SetFloat( "_QueueControl", settings._QueueControl );
		if(settings.unity_Lightmaps.value != null) sheet.properties.SetTexture( "unity_Lightmaps", settings.unity_Lightmaps );
		if(settings.unity_LightmapsInd.value != null) sheet.properties.SetTexture( "unity_LightmapsInd", settings.unity_LightmapsInd );
		if(settings.unity_ShadowMasks.value != null) sheet.properties.SetTexture( "unity_ShadowMasks", settings.unity_ShadowMasks );
		context.command.BlitFullscreenTriangle( context.source, context.destination, sheet, 0 );
	}
}
#endif
