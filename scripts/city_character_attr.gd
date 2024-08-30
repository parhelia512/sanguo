extends Panel

var RadarChartStatsScene = preload("res://scenes/RadarChartStats.tscn")
var has_chart_scene = false

func _ready() -> void:
	SignalBus.connect("show_city_hero_info", _on_show_city_hero_info)
	
func _on_show_city_hero_info():
	var nameId = Global.cur_hero_id
	var character = Global.characters[nameId]
	var attrs = character.attrs
	$Name/RichTextLabel.text = set_message_name(character.name)
	$Head.texture = load(character.headImg)
	$Wu/RichTextLabel.text = set_message_name(Global.weapons[character.weaponId].name)
	$Fang/RichTextLabel.text = set_message_name(Global.armors[character.armorId].name)
	$Skill/RichTextLabel.text = get_skill_desc(nameId)
	# TODO: bug-暂时用生成实例、移除实例的方式
	if(has_chart_scene):
		$".".remove_child($".".get_child(6))
		has_chart_scene = false
	if(!has_chart_scene):
		var RadarChartStats = RadarChartStatsScene.instantiate()
		RadarChartStats.position = Vector2(296, 100)
		RadarChartStats.stats = [attrs["command"], attrs["force"], attrs["intelligence"], attrs["politics"], attrs["morality"], attrs["physical_strength"], attrs["speed"], attrs["level"]]
		$".".add_child(RadarChartStats)
		has_chart_scene = true
	
func set_message_name(text):
	return "[color=#91c2d5][u][url]"+  text +"[/url][/u][/color]"

func get_skill_desc(nameId):
	var skillsDesc = ""
	var skillIds = Global.characters[nameId].skillIds
	for i in Global.characters[nameId].skillIds:
		if(Global.skills[i].type == "normal"):
			skillsDesc += "[color=#91c2d5][u][url]"+  Global.skills[i].name +"[/url][/u][/color]" + " "
		if(Global.skills[i].type == "self"):
			skillsDesc += "[color=#ffe219][u][url]"+  Global.skills[i].name +"[/url][/u][/color]" + " "
		if(Global.skills[i].type == "self_bad"):
			skillsDesc += "[color=#ff5437][u][url]"+  Global.skills[i].name +"[/url][/u][/color]" + " "
	return skillsDesc

func _on_button_pressed() -> void:
	$".".hide()
